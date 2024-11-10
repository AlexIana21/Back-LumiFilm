using Microsoft.AspNetCore.Mvc;
namespace Models;

public class Sala
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    protected int Capacidad {get; set;}

    // Relación con horarios.
     public List<Horario> Horarios { get; set; } = new List<Horario>();

    // Relación con días.
    public List<Dia> Dia { get; set; } = new List<Dia>();


    public Sala(int id, string nombre, int capacidad, List<Horario> horarios, List<Dia> dias)
    {
        Id = id;
        Nombre = nombre;
        Capacidad = capacidad;
        Horarios = horarios ?? new List<Horario>(); // usamos ?? para que nunca se inicialicen null y explote.
        Dia = dias ?? new List<Dia>();
    }
   
}
