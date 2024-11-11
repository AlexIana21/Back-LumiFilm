namespace Models;

public class Horario
{
    public int Id { get; set; }
    public DateTime Hora { get; set; }
    public Pelicula Pelicula { get; set; }

    public Horario(int id, DateTime hora, Pelicula pelicula)
    {
        Id = id;
        Hora = hora;
        Pelicula = pelicula;
    }

    public Horario() { }
}