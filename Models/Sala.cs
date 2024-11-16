using Microsoft.AspNetCore.Mvc;
namespace Models;

public class Sala
{
    private static int counterId = 1;
    public int Id { get; set; }
    public Sala() {
        Id = counterId++;
    }
}
