using Utils;

namespace Models;

public class Sesion
{
    public int Id { get; set; }
    public DateOnly Dia { get; set; } 
    public TimeOnly Hora { get; set; }
    public int PeliculaId{ get; set; } 
    public int SalaId { get; set; }
   
    public Sesion() { }

}
