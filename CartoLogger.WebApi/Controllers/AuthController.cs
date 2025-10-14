using Microsoft.AspNetCore.Mvc;
using CartoLogger.Domain;
using CartoLogger.Domain.Constraints;
using CartoLogger.Domain.Entities;
using CartoLogger.WebApi.DTO;
using CartoLogger.WebApi.DTO.Http;

namespace CartoLogger.WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IUnitOfWork unitOfWork) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest req)
    {
        Task<User?> task;
        if (EmailConstaints.IsValidEmail(req.Identity, out string? emailErr))
        {
            task = _unitOfWork.Users.GetByEmail(req.Identity);
        }
        else
        {
            task = _unitOfWork.Users.GetByName(req.Identity);
        }

        User? user = await task;
        if (user is null)
        {
            return Unauthorized(new
            {
                error = emailErr ?? "invalid credentials"
            });
        }

        if (!PasswordConstraints.VerifyPassword(req.Password, user.PasswordHash))
        {
            return Unauthorized(new { error = "invalid credentials" });
        }


        await _unitOfWork.Users.LoadMaps(user);
        return Ok(new LoginResponse
        {
            User = new UserDto
            {
                Id = user.Id,
                Name = user.Name
            },
            Maps = user.Maps.Select(m =>
                new MapDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description
                }
            )
        });
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest req)
    {

        if (!EmailConstaints.IsValidEmail(req.Email, out string? emailErr))
        {
            return BadRequest(new {
                error = emailErr ?? "invalid email format"
            });
        }


        if (!PasswordConstraints.IsValidPassword(req.Password, out string? passErr))
        {
            return BadRequest(new {
                error = passErr ?? "password is not strong enough"
            });
        }

        var userByName = await _unitOfWork.Users.GetByName(req.Username);
        if (userByName != null)
        {
            return Conflict(new { error = "username already in use" });
        }


        var userByEmail = await _unitOfWork.Users.GetByEmail(req.Email);
        if (userByEmail != null)
        {
            return Conflict(new { error = "email is already in use" });
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

        return Ok(new UserDto
        {
            Id = user.Id,
            Name = user.Name
        });
    }
}
