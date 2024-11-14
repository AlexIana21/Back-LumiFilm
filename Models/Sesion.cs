namespace Models;

public class Sesion
{
    private static int contadorId = 1;
    public int Id {get; private set;} = 1;
    public string Dia { get; set; } 
    public DateTime Hora { get; set; }
    public Pelicula Pelicula { get; set; } 

    public Sesion(string dia, DateTime hora, Pelicula pelicula)
    {
        Id = contadorId++;
        Dia = dia;
        Hora = hora;
        Pelicula = pelicula;
    }

  
    public Sesion() { }
}