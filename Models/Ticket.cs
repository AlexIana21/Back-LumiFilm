namespace Models;

public class Ticket {
    private static int contadorId = 1;
    public int Id {get; private set;}
    public List<Asiento> AsientosReservados { get; set; }
    public Sesion Sesion {get; set;}
    public DateTime FechaTicket {get; set;}
    public string Nombre {get; set;}
    public string Apellido {get; set;}
    public string Telefono {get; set;}
    public string Mail {get; set;}
    public double PrecioTotal {get; set;}


    public Ticket( Sesion sesion, string nombre, string apellido, string telefono, string mail, double precioTotal) {
        Id = contadorId++;
        Sesion = sesion;
        AsientosReservados = new List<Asiento>();
        FechaTicket = DateTime.Now;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        Mail = mail;
        PrecioTotal = precioTotal;
    }

    
}