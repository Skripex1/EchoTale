using Domain.Common;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } 
    public string Email { get; set; }
    public string Password { get; set; } 
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string PhoneNumber { get; set; } 
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public GenderType Gender { get; set; } 
    public UserType UserType { get; set; }
}