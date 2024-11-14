namespace Models;

public class Sesion
{
    public int Id { get; set; }
    public string Dia { get; set; } 
    public DateTime Hora { get; set; }
    public Pelicula Pelicula { get; set; } 

    public Sesion(int id, string dia, DateTime hora, Pelicula pelicula)
    {
        Id = id;
        Dia = dia;
        Hora = hora;
        Pelicula = pelicula;
    }

  
    public Sesion() { }
}