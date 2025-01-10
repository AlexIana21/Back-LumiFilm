namespace Models;

public class Opiniones
{
    private static int contadorId = 1;
    public int Id { get; private set; }
    public Pelicula Pelicula { get; set; }
    public string Texto { get; set; }
    public string Username { get; set; }
    public int Calificacion { get; set; }

    public Opiniones(Pelicula pelicula, string texto, string username, int calificacion)
    {
        Id = contadorId++;
        Pelicula = pelicula;
        Texto = texto;
        Username = username;
        Calificacion = calificacion;
    }
}
