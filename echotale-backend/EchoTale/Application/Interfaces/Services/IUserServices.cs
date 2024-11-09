using Application.DTOs;

namespace Application.Interfaces.Services;

public interface IUserServices
{
    Task <UserResponseDto> RegisterUserAsync(RegisterUserRequestDto registerUserRequestDto);
}