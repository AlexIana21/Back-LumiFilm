namespace Models;

public class Asiento
{
    public int Id { get; set; }
    public int Columna { get; set; }
    public char Fila { get; set;}
    public bool Ocupado { get; set; }

     public Asiento(int id, int columna, char fila, bool ocupado)
    {
        Id = id;
        Columna = columna;
        Fila = fila;
        Ocupado = ocupado;
    }
   
     public int SalaId { get; set; }
}