using Utils;

namespace Models;

public class Session
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int MovieId{ get; set; } 
    public int ScreenId { get; set; }
    public Session() { }

}
