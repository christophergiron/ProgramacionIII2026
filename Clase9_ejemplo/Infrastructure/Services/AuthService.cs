using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Clase9_Ejemplo.Application.DTOs;
using Clase9_Ejemplo.Application.Interfaces;
using Clase9_Ejemplo.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Clase9_Ejemplo.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<TokenDto?> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return null;

        return GenerateToken(user);
    }

    public async Task<TokenDto?> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existingUser != null)
            return null;

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = "User"
        };

        await _userRepository.AddAsync(user);
        return GenerateToken(user);
    }

    private TokenDto GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration["Jwt:Secret"] ?? "SuperSecretKeyForJwtToken12345678901234567890"));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var expiresAt = DateTime.UtcNow.AddHours(24);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"] ?? "Clase9Api",
            audience: _configuration["Jwt:Audience"] ?? "Clase9Client",
            claims: claims,
            expires: expiresAt,
            signingCredentials: credentials
        );

        return new TokenDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpiresAt = expiresAt
        };
    }
}
