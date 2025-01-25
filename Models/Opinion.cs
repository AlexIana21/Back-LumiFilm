namespace Models;

public class Comentario
{
    public int Id { get;  set; }
    public string Texto { get; set; }
    public DateTime Fecha {get;set;}
    public int UsuarioId { get; set; }
    public int Puntuacion { get; set; }
    public int PeliculaId { get; set; }

    public Comentario(){
    }
}
