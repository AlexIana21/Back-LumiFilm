namespace Models;

public class Pelicula {
    
    public string Titulo {get;set;} = "";

    public string Sinopsis {get;set;} = "";

    public int Duracion {get;set;}

    public int Clasificacion {get;set;}

    public string Genero {get;set;} = "";

    public Pelicula(string titulo, string sinopsis, int duracion, int clasificacion, string genero) {
        Titulo = titulo;
        Sinopsis = sinopsis;
        Duracion = duracion;
        Clasificacion = clasificacion;
        Genero = genero;
    }
}
