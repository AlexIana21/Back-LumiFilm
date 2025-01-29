namespace Models;

public class Order
{
  public int Id { get; set; }
  public string StripeId { get; set; }
  public double Price{ get; set; }
  public  OrderStatus Status { get; set; }
  public DateTime Date { get; set; }
  public int UserId { get; set; }
  public int SessionId { get; set; }

  public Order() { }

  public enum OrderStatus { Pending, Processing, Completed, Declined }
  }