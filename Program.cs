var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddScoped<IHelloWorldService, HelloworldService>();
builder.Services.AddScoped<IHelloWorldService>(p => new HelloworldService());

/*
    la orden en la cual se ejecutan los middlewares en .NET, SON:
    * ExceptionHandler
    * HSTS
    * HttpRedirection
    * Static Files
    * Routing
    * CORS
    * Autentication
    * Autorization
    * --------- AQUI VAN LOS MIDDLEWARES CUSTOMIZADOS
    * ENDPOINT
    
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

// Creamos api de bienvenida
// app.UseWelcomePage();
// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
