using AcessControlQR.Application.Interfaces;
using AcessControlQR.Domain.DTO;
using AcessControlQR.Domain.Models;

namespace AcessControlQR.Application.Services
{
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> RegisterUserAsync(RegisterUserDTO registerUserDto)
    {
        var existingUser = await _userRepository.GetByUsernameAsync(registerUserDto.Username);
        if (existingUser != null)
            throw new Exception("User already registered.");
        
        var user = new User
        {
            Username = registerUserDto.Username,
            Email = registerUserDto.Email,
            Role = registerUserDto.Role,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password),
            CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),
            UpdatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified)
        };

        user.SetPassword(registerUserDto.Password);
        await _userRepository.AddAsync(user);
        
        return true;
    }
}
}