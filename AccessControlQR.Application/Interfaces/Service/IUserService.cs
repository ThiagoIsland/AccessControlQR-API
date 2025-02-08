using AcessControlQR.Domain.DTO;

namespace AcessControlQR.Application.Interfaces;

public interface IUserService
{
    public Task<bool> RegisterUserAsync(RegisterUserDTO registerUserDto);
}