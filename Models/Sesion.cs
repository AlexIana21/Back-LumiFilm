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
        if (capacidad > 10)
        {
            throw new ArgumentException("La capacidad no puede exceder 10 asientos.");
        }

        Id = contadorId++;
        Dia = dia;
        Hora = hora;
        Pelicula = pelicula;
        Sala = sala;
        GenerarAsientos(capacidad);
    }

    private void GenerarAsientos(int capacidad)
    {
        int columnas = 10; 
        int filas = (int)Math.Ceiling((double)capacidad / columnas);

        for (int x = 0; x < filas; x++) 
        {
            string filaActual = ((char)('A' + x)).ToString(); 

            for (int y = 1; y <= columnas; y++)
            {
                if (Asientos.Count >= capacidad)
                {
                    break;
                }

                Asientos.Add(new Asiento
                {
                    Fila = filaActual, 
                    Columna = columnas,
                    Ocupado = false
                });
            }
        }
    }

}
