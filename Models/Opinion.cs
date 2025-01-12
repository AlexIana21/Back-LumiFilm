namespace Models;

public class Opiniones
{
    private static int contadorId = 1;
    public int Id { get; private set; }
    public int PeliculaID { get; set; }
    public string Username { get; set; }
    public DateTime FechaComentario {get;set;}
    public string Texto { get; set; }
    public int Calificacion { get; set; }

    public Opiniones(){
        Id = contadorId++;
    }
}
