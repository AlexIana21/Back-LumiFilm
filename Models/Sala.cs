using Microsoft.AspNetCore.Mvc;
namespace Models;

public class Sala
{
    private static int counterId = 1;
    public int Id { get; set; }
    public int Capacidad { get; set; } 

    public List<Sesion> Sesion {get; set;} = new List<Sesion>();

     // Relación con asientos para poder tener el ID de la sala.
    public List<Asiento> Asientos { get; set; } = new List<Asiento>();

    public Sala(int id, int capacidad)
    {
        if (capacidad > 10)
        {
            throw new ArgumentException("La capacidad no puede exceder 10 asientos."); // try-catch
        }

        Id = counterId++;
        Capacidad = capacidad;

   
        int columnas = 3; 
        int filas = (int)Math.Ceiling(capacidad / (double)columnas); // sacar filas

        //ejemplo de anton X e Y adaptado 

        for (int fila = 0; fila < filas; fila++) 
        {
            for (int columna = 1; columna <= columnas; columna++) 
            {
                int asientoNumero = fila * columnas + columna; // Calcular el número de asiento
                if (asientoNumero > capacidad) break; 
                Asientos.Add(new Asiento
                {
                    Columna = columna,
                    Fila = "A", 
                    Ocupado = false,
                    SalaId = id
                });
            }
        }
    }

    public Sala() { }
}
