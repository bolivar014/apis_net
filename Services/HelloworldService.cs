public class HelloworldService : IHelloWorldService {
    public string GetHelloWorld() {
        return "HelloWorld!!";
    }
}

// Retornamos interfaz
public interface IHelloWorldService {
    string GetHelloWorld();
}