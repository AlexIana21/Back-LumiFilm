using Microsoft.AspNetCore.Mvc;
namespace Models;

public class Sala
{
    private static int counterId = 1;
    public int Id { get; set; }
    public int Capacidad { get; set; } 

    public List<Sesion> Sesion {get; set;} = new List<Sesion>();
    
    public Sala(int id, int capacidad, List<Sesion> sesion)
    {
    Id = counterId++; 
    Capacidad = capacidad;
    Sesion = sesion ?? new List<Sesion>();
    }
    public Sala() { }
}
