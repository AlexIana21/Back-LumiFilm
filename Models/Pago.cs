namespace Models;
public class Pago
{
  public int Id { get; set; }
  public string PaymentStripeId { get; set; }
  public string Estado { get; set; }
  public DateTime FechaPago { get; set; }
  public int UsuarioId { get; set; }
  public int TicketId { get; set; }

  public Pago()
  {

  }
}