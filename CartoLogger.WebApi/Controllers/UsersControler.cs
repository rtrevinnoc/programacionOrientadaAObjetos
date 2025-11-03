using Microsoft.AspNetCore.Mvc;
using CartoLogger.Domain;
using CartoLogger.Domain.Entities;
using CartoLogger.WebApi.DTO;

namespace CartoLogger.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IUnitOfWork unitOfWork) : CartoLoggerController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(
        [FromRoute] int id, [FromQuery] bool maps = false,
        [FromQuery(Name = "favorite-maps")] bool favoriteMaps = false
    ) {
        User? user =  await _unitOfWork.Users.GetById(id);
        if(user is null) { return UserNotFound(id); }

        if(maps) { await _unitOfWork.Users.LoadMaps(user); }
        if(favoriteMaps) { await _unitOfWork.Users.LoadFavoriteMaps(user); }
        return Ok(UserDto.FromUser(user, maps, favoriteMaps));
    }


    [HttpGet("{id}/maps")]
    public async Task<IActionResult> GetUserMaps([FromRoute] int id)
    {
        if(!await _unitOfWork.Users.Exists(id))
        {
            return UserNotFound(id);
        }
        var maps = await _unitOfWork.Users.GetMapsById(id);
        return Ok(maps.Select(map => MapDto.FromMap(map)));
    }


    [HttpPost("{id}/add-map-to-favorites/{mapId}")]
    public async Task<IActionResult> AddMapToFavorites(
        [FromRoute] int id, [FromRoute] int mapId
    ) {
        if(!await _unitOfWork.Users.Exists(id))
        {
            return UserNotFound(id);
        }
        
        if(!await _unitOfWork.Maps.Exists(mapId))
        {
            return MapNotFound(mapId);
        }

        await _unitOfWork.Users.AddMapToFavorites(id, mapId);
        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }


    [HttpDelete("{id}/remove-map-from-favorites/{mapId}")]
    public async Task<IActionResult> RemoveMapFromFavorites(
        [FromRoute] int id, [FromRoute] int mapId
    ) {
        if(!await _unitOfWork.Users.Exists(id))
        {
            return UserNotFound(id);
        }
        
        if(!await _unitOfWork.Maps.Exists(mapId))
        {
            return MapNotFound(id);
        }

        if(!await _unitOfWork.Users.MapIsInFavorites(id, mapId))
        {
            return Problem(
                title: "Map is not favorited",
                detail: $"user with id: {id} does not have map with id: {mapId} in favorites",
                statusCode: StatusCodes.Status400BadRequest
            );
        }
        
        await _unitOfWork.Users.RemoveMapFromFavorites(id, mapId);
        return NoContent();
    }


    [HttpGet("{id}/favorite-maps")]
    public async Task<IActionResult> GetUserFavoriteMaps([FromRoute] int id)
    {
        if(!await _unitOfWork.Users.Exists(id))
        {
            return UserNotFound(id);
        }
        var favs = await _unitOfWork.Users.GetFavoriteMapsById(id);
        return Ok(favs.Select(map => MapDto.FromMap(map)));
    }
}
