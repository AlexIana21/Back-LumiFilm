namespace Models;

public class Pelicula {

    public int Id {get; set;}
    
    public string Titulo {get;set;} = "";

    public string Sinopsis {get;set;} = "";

    public int Duracion {get;set;}

    public int Clasificacion {get;set;}

    public string Genero {get;set;} = "";

    public Pelicula(int id, string titulo, string sinopsis, int duracion, int clasificacion, string genero) {
        Id = id;
        Titulo = titulo;
        Sinopsis = sinopsis;
        Duracion = duracion;
        Clasificacion = clasificacion;
        Genero = genero;
    }

}
