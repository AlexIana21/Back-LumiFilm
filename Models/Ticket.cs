namespace Models;

public class Ticket {
    private static int contadorId = 1;
    public int Id {get; private set;}
    public Pelicula Pelicula {get; set;}
    public Sala Sala {get; set;}
    public List<Asiento> AsientosReservados { get; private set; }
    private List<(Entrada entrada, int cantidad)> entradas;
    public DateTime FechaTicket {get; private set;}
    public double Total {
        get {
            double totalPedido = 0;
                foreach(var(entrada, cantidad) in entradas) {
                    totalPedido += entrada.Precio * cantidad;
                }
            return totalPedido;
        }
    }

    public static int TotalTickets {get; private set;} = 1;

    public Ticket(Pelicula pelicula, Sala sala) {
        Id = contadorId++;
        Pelicula = pelicula;
        Sala = sala;
        AsientosReservados = new List<Asiento>();
        entradas = new List<(Entrada entrada, int cantidad)>();
        FechaTicket = DateTime.Now;
        TotalTickets++;
    }
}