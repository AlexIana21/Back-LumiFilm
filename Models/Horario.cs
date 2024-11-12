namespace Models;

public class Horario
{
    public int Id { get; set; }
    public DateTime Hora { get; set; }
    public Pelicula Pelicula { get; set; }
    public Dia Dia { get; set; } 

    public Horario(int id, DateTime hora, Pelicula pelicula, Dia dia)
    {
        Id = id;
        Hora = hora;
        Pelicula = pelicula;
        Dia = dia;
    }

    public Horario() { }
}