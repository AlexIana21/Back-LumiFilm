namespace Models;

public class Dia
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Dia(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    public Dia() { }
}