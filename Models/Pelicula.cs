namespace Models;

public class Pelicula {
    public int Id {get; set;}
    public string Titulo {get;set;}
    public string Sinopsis {get;set;}
    public int Duracion {get;set;}
    public int Clasificacion {get;set;}
    public string Genero {get;set;}
    public string Direccion {get; set;}
    public string Imagen {get; set;}

    public Pelicula(int id, string titulo, string sinopsis, int duracion, int clasificacion, string genero, string direccion, string imagen) {
        Id = id;
        Titulo = titulo;
        Sinopsis = sinopsis;
        Duracion = duracion;
        Clasificacion = clasificacion;
        Genero = genero;
        Direccion = direccion;
        Imagen = imagen;
    }

}
