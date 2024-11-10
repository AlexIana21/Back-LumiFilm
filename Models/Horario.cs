namespace Models;

public class Horario
{
    public int Id { get; set; }
    public DateTime Hora { get; set; }
    public string Pelicula { get; set; }

    public Horario(int id, DateTime hora, string pelicula)
    {
        Id = id;
        Hora = hora;
        Pelicula = pelicula;
    }

    public Horario() { }
}