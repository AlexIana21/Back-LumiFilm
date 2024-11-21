namespace Models;

public class Ticket {
    private static int contadorId = 1;
    public int Id {get; private set;}
    public Pelicula Pelicula {get; set;}
    public Sala Sala {get; set;}
    public List<Asiento> AsientosReservados { get; set; }
    public List<(Entrada entrada, int cantidad)> entradas;
    public DateTime FechaTicket {get; set;}
    public string Nombre {get; set;}
    public string Apellido {get; set;}
    public string Telefono {get; set;}
    public string Mail {get; set;}
    public double Total {
        get {
            double totalPedido = 0;
                foreach(var(entrada, cantidad) in entradas) {
                    totalPedido += entrada.Precio * cantidad;
                }
            return totalPedido;
        }
    }

    public static int TotalTickets {get; set;} = 1;

    public Ticket(Pelicula pelicula, Sala sala, string nombre, string apellido, string telefono, string mail) {
        Id = contadorId++;
        Pelicula = pelicula;
        Sala = sala;
        AsientosReservados = new List<Asiento>();
        entradas = new List<(Entrada entrada, int cantidad)>();
        FechaTicket = DateTime.Now;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        Mail = mail;
        TotalTickets++;
    }
}