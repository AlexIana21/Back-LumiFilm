namespace Models;

public class Pelicula {
    private static int contadorId = 1;
    public int Id {get; private set;}
    public string Titulo {get;set;}
    public string Sinopsis {get;set;}
    public int Duracion {get;set;}
    public int Clasificacion {get;set;}
    public string Genero {get;set;}
    public string Direccion {get; set;}

    public string Imagen {get; set;}

    public Pelicula(string titulo, string sinopsis, int duracion, int clasificacion, string genero, string direccion, string imagen) {
        Id = contadorId++;
        Titulo = titulo;
        Sinopsis = sinopsis;
        Duracion = duracion;
        Clasificacion = clasificacion;
        Genero = genero;
        Direccion = direccion;
        Imagen = imagen;
    }

}
