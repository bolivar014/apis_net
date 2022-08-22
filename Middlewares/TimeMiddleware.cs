// Creamos clase publica para middleware que retorna la hora del servidor
public class TimeMiddleware {
    // Invocamos middleware siguiente
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest) {
        // Asignamos a next el llamado del siguiente middleware a ejecutar
        next = nextRequest;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context) {

        // En caso que obtenga una variable tipo "time" en el request
        if(context.Request.Query.Any(p => p.Key == "time")) {
            // Retornamos response con la fecha y hora actual del servidor
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }

        // Validamos
        if(!context.Response.HasStarted) {
            // 
            await next.Invoke(context);
        }
        
    }
}
public static class TimeMiddlewareExtension {

    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder) {
        // Retornamos middleware
        return builder.UseMiddleware<TimeMiddleware>();
    }
}