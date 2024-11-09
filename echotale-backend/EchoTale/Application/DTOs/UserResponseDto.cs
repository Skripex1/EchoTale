using Domain.Common;

namespace Application.DTOs;

public class UserResponseDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public GenderType? Gender { get; set; }
    public  UserType UserType { get; set; }
}