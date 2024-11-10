namespace Models;

public class Entrada {

    public int Id {get; set;}

    public string Tipo {get; set;} = "";

    public int Precio {get; set;}

    public Entrada(int id, string tipo, int precio) {
        Id = id;
        Tipo = tipo;
        Precio = precio;
        if (precio < 0) {
            throw new ArgumentException("Error: El precio no puede ser negativo");
        }
    }

}