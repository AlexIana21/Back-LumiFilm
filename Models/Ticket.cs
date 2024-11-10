namespace Models;

public class Ticket {

    private static int contadorId = 1;
    public int Id {get; private set;}

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
        Id = contadorId++;
        entradas = new List<(Entrada entrada, int cantidad)>();
        FechaTicket = DateTime.Now;
        TotalTickets++;
    }
    
}