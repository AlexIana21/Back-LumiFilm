namespace Models;

public class Entrada {
    private static int contadorId = 1;
    public int Id {get; set;}
    public string Tipo {get; set;}
    public double Precio {get; set;}
    public Entrada(string tipo, double precio) {
        Id = contadorId++;
        Tipo = tipo;
        Precio = precio;
        if (precio < 0) {
            throw new ArgumentException("Error: El precio no puede ser negativo");
        }
    }
}