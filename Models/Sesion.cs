using Utils;

namespace Models;

public class Sesion
{
    private static int contadorId = 1;
    public int Id { get; private set; }
    public DateOnly Dia { get; set; } 
    public TimeOnly Hora { get; set; }
    public Pelicula Pelicula { get; set; } 
    public Sala Sala { get; set; }
    public List<Asiento> Asientos { get; set; } = new List<Asiento>();

    public Sesion(DateOnly dia, TimeOnly hora, Pelicula pelicula, Sala sala, int capacidad)
    {
        try
        {
            if (capacidad > 100)
            {
                throw new ArgumentException("La capacidad no puede exceder 100 asientos.");
            }

            Id = contadorId++;
            Dia = dia;
            Hora = hora;
            Pelicula = pelicula;
            Sala = sala;
            GenerarAsientos(capacidad);
        }
        catch (ArgumentException ex)
        {
            // Registrar el error
            Logger.LogError(ex);

            // Asignar valores por defecto para evitar la interrupción
            Id = contadorId++;
            Dia = dia;
            Hora = hora;
            Pelicula = pelicula;
            Sala = sala;
            Asientos = new List<Asiento>(); // No se generan asientos debido al error
        }
    }

    private void GenerarAsientos(int capacidad)
    {
        int columnas = 9; 
        int filas = (int)Math.Ceiling(capacidad / (double)columnas);

        for (int fila = 0; fila < filas; fila++) 
        {
            for (int columna = 1; columna <= columnas; columna++)
            {
                int asientoNumero = fila * columnas + columna;
                if (asientoNumero > capacidad) break; 
                
                Asientos.Add(new Asiento
                {
                    Columna = columna,
                    Fila = (char)('A' + fila),
                    Ocupado = false,
                    Precio = 7.5
                });
            }
        }
    }
}
