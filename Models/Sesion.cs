namespace Models;

public class Sesion
{
    private static int contadorId = 1;
    public int Id { get; private set; }
    public string Dia { get; set; } 
    public DateTime Hora { get; set; }
    public Pelicula Pelicula { get; set; } 
    public List<Asiento> Asientos { get; set; } = new List<Asiento>();

    public Sesion(string dia, DateTime hora, Pelicula pelicula, int capacidad)
    {
        if (capacidad > 10)
        {
            throw new ArgumentException("La capacidad no puede exceder 10 asientos.");
        }

        Id = contadorId++;
        Dia = dia;
        Hora = hora;
        Pelicula = pelicula;

        GenerarAsientos(capacidad);
    }

    private void GenerarAsientos(int capacidad)
    {
        int columnas = 3; 
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
                    Fila = "A" + fila, 
                    Ocupado = false,
                    SalaId = Id 
                });
            }
        }
    }

    public Sesion() { }
}
