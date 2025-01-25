namespace Models;

public class Sala
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Capacidad { get; set; }
    public int NFilas { get; set; }
    public int NColumnas { get; set; }
    public bool Disponible { get; set; }
    
    public Sala() {
    }
}
