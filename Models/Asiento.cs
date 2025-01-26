namespace Models;

public class Asiento
{
    public int Id {get; set;}
    public char Fila { get; set;}
    public int Columna { get; set; }
    public string Estado { get; set; }
    public double Precio {get; set; }
    public bool EsVip {get; set;}
    public int SalaId {get; set;}
}