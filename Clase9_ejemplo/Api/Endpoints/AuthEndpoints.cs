using Clase9_Ejemplo.Application.DTOs;
using Clase9_Ejemplo.Application.Interfaces;

namespace Clase9_Ejemplo.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/auth").WithTags("Autenticación");

        group.MapPost("/register", async (RegisterDto dto, IAuthService authService) =>
        {
            var result = await authService.RegisterAsync(dto);
            return result is null
                ? Results.BadRequest(new { message = "El usuario ya existe" })
                : Results.Ok(result);
        })
        .WithName("Register")
        .WithOpenApi();

        group.MapPost("/login", async (LoginDto dto, IAuthService authService) =>
        {
            var result = await authService.LoginAsync(dto);
            return result is null
                ? Results.Unauthorized()
                : Results.Ok(result);
        })
        .WithName("Login")
        .WithOpenApi();
    }
}
