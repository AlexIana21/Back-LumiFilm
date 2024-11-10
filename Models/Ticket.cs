namespace Models;

public class Ticket {
    public static int Id {get; private set;} = 1;

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

    public static int TotalTickets {get; private set;}

    public Ticket() {
        Id++;
        entradas = new List<(Entrada entrada, int cantidad)>();
        FechaTicket = DateTime.Now;
        TotalTickets++;
    }
    
}