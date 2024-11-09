using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EchoTale.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserServices _userServices;
    private readonly IUserRepository _userRepository;

    public UsersController(IUserServices userServices , IUserRepository repository)
    {
        _userServices = userServices;
        _userRepository = repository;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUserAsync(RegisterUserRequestDto registerUserRequestDto)
    {
        var response = await _userServices.RegisterUserAsync(registerUserRequestDto);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users);
    }
    
    [HttpGet("{id}")]
    
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return Ok(user);
    }
    
    [HttpGet("username/{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var user = await _userRepository.GetByUsernameAsync(username);
        return Ok(user);
    }
    
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        return Ok(user);
    }
    
    public async Task<IActionResult> UpdateUser(User user)
    {
        var updatedUser = await _userRepository.UpdateAsync(user);
        return Ok(updatedUser);
    }
    
    [HttpDelete("{id}")]
    
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var deleted = await _userRepository.DeleteAsync(id);
        return Ok(deleted);
    }
    
    
    [HttpGet("usernameoremail/{usernameOrEmail}")]
    public async Task<IActionResult> GetUserByUsernameOrEmail(string usernameOrEmail)
    {
        var user = await _userRepository.GetByUsernameOrEmailAsync(usernameOrEmail);
        return Ok(user);
    }
    
    [HttpGet("unique/email/{email}")]
    public async Task<IActionResult> IsEmailUniqueAsync(string email)
    {
        var isUnique = await _userRepository.IsEmailUniqueAsync(email);
        return Ok(isUnique);
    }
    
    [HttpGet("unique/username/{username}")]
    
    public async Task<IActionResult> IsUsernameUniqueAsync(string username)
    {
        var isUnique = await _userRepository.IsUsernameUniqueAsync(username);
        return Ok(isUnique);
    }
    
}