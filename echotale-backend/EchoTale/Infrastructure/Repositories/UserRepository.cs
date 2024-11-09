using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> AddAsync(User user)
    {
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user.Id;
    }

    public async Task<IEnumerable<User?>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
       return await _dbContext.Users.FirstOrDefaultAsync(u => u != null && u.Email == email);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u != null && u.Id == id);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u != null && u.Username == username);
    }

    public async Task<User?> GetByUsernameOrEmailAsync(string usernameOrEmail)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u != null && (u.Username == usernameOrEmail || u.Email == usernameOrEmail));
    }

    public async Task<User> UpdateAsync(User user)
    {
        var id = user.Id;
        bool existingUser = _dbContext.Users.Any(u => u.Id == id);
        if (!existingUser)
        {
            throw new ApplicationException("User not found.");
        }
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new ApplicationException("User not found.");
        }
        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        return await _dbContext.Users.AllAsync(u => u.Email != email);
    }

    public async Task<bool> IsUsernameUniqueAsync(string username)
    {
        return await _dbContext.Users.AllAsync(u => u.Username != username);
    }
}