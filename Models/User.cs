using Microsoft.AspNetCore.Identity;
using Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
    public User () {}
    public enum UserRole { Admin, User }
}