using Microsoft.AspNetCore.Mvc;
using CartoLogger.Domain;
using CartoLogger.Domain.Constraints;
using CartoLogger.Domain.Entities;
using CartoLogger.WebApi.DTO;

namespace CartoLogger.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IUnitOfWork unitOfWork) : CartoLoggerController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req)
    {
        Task<User?> task;
        if (EmailConstaints.IsValidEmail(req.Identity, out string? _))
        {
            task = _unitOfWork.Users.GetByEmail(req.Identity);
        }
        else
        {
            task = _unitOfWork.Users.GetByName(req.Identity);
        }

        User? user = await task;
        if(user is null ||!PasswordConstraints.VerifyPassword(req.Password, user.PasswordHash)
        ) {
            return Problem( 
                title: "Unauthorized",
                detail: "Invalid credentials",
                statusCode: StatusCodes.Status401Unauthorized
            );
        }

        return Ok(new { user.Id });
    }


    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest req)
    {

        if (!EmailConstaints.IsValidEmail(req.Email, out string? emailErr))
        {
            return Problem(
                title: "Bad email",
                detail: emailErr ?? "invalid email format",
                statusCode: StatusCodes.Status400BadRequest
            );
        }

        if (!PasswordConstraints.IsValidPassword(req.Password, out string? passErr))
        {
            return Problem(
                title: "Bad password",
                detail: passErr ?? "password is not strong enough",
                statusCode: StatusCodes.Status400BadRequest
            );
        }

        if (await _unitOfWork.Users.ExistsWithName(req.Username))
        {
            return Problem(
                title: "Bad password",
                detail: "username already in use",
                statusCode: StatusCodes.Status409Conflict
            );
        }

        if (await _unitOfWork.Users.ExistsWithEmail(req.Email))
        {
            return Problem(
                title: "Bad email",
                detail: "email is already in use",
                statusCode: StatusCodes.Status409Conflict
            );
        }

        string passwordHash = PasswordConstraints.HashPassword(req.Password);

        var user = new User
        {
            Name = req.Username,
            Email = req.Email,
            PasswordHash = passwordHash
        };

        _unitOfWork.Users.Add(user);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }
}
