namespace Models;

public class Seat
{
    public int Id { get; set; }
    public string Status { get; set; }
    public double Price { get; set; }
    public SeatType Type { get; set; }  
    public int ScreenId { get; set; }
    public Seat() { }

    public enum SeatType { Standard, VIP }
}



