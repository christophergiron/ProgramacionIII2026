using Clase9_Ejemplo.Application.DTOs;

namespace Clase9_Ejemplo.Application.Interfaces;

public interface IAuthService
{
    Task<TokenDto?> LoginAsync(LoginDto dto);
    Task<TokenDto?> RegisterAsync(RegisterDto dto);
}
