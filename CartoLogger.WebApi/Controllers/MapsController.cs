using Microsoft.AspNetCore.Mvc;
using CartoLogger.Domain;
using CartoLogger.Domain.Entities;
using CartoLogger.WebApi.DTO;

namespace CartoLogger.WebApi.Controllers;

[ApiController]
[Route("api/maps")]
public class MapsController(IUnitOfWork unitOfWork) : CartoLoggerController
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


    [HttpPost]
    public async Task<IActionResult> CreateMap(CreateMapRequest req) {

        if(!Map.TitleConstraints
               .IsValidTitle(req.Title, out string? titleErr)
        ) {
            return Problem(
                title: "Bad Title",
                detail:titleErr,
                statusCode: StatusCodes.Status400BadRequest
            );
        }

        if(!Map.DescriptionConstraints
               .IsValidDescription(req.Description, out string? descErr)
        ) {
           return Problem(
                title: "Bad Description",
                detail: descErr,
                statusCode: StatusCodes.Status400BadRequest
            );
        }
        
        if(req.UserId is int id && !await _unitOfWork.Users.Exists(id))
        {
            return UserNotFound(id);
        }

        var map = new Map
        {
            UserId = req.UserId,
            Title = req.Title,
            Description = req.Description,
            View = req.View
        };

        _unitOfWork.Maps.Add(map);
        await _unitOfWork.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetMapById),
            new { id = map.Id },
            MapDto.FromMap(map)
        );
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetMapById(
        [FromRoute] int id, [FromQuery] bool features = false
    ) {
        var map = await _unitOfWork.Maps.GetById(id);
        if(map is null) { return MapNotFound(id); }

        if(features) { await _unitOfWork.Maps.LoadFeatures(map); }

        await _unitOfWork.Maps.LoadFeatures(map);
        return Ok(MapDto.FromMap(map));
    }

    
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateMap(
        [FromRoute] int id, [FromBody] UpdateMapRequest req
    ) {
        var map = await _unitOfWork.Maps.GetById(id);
        if(map is null) { return MapNotFound(id); }

        if(req.Title is not null) {
            if(!Map.TitleConstraints
                   .IsValidTitle(req.Title, out string? err)
            ) {
                return Problem(
                    title: "Bad Title",
                    detail: err,
                    statusCode: StatusCodes.Status400BadRequest
                );
            }
            map.Title = req.Title;
        }

        if(req.Description is not null)
        {
            if(!Map.DescriptionConstraints
                   .IsValidDescription(req.Description, out string? err)
            ) {
                return Problem(
                    title: "Bad Description",
                    detail: err,
                    statusCode: StatusCodes.Status400BadRequest
                );
            }
            map.Description = req.Description;
        }
        
        if(req.View is not null) { map.View = req.View; }

        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMap([FromRoute] int id)
    {
        if(!await _unitOfWork.Maps.Exists(id))
        {
            return MapNotFound(id);
        }
        await _unitOfWork.Maps.RemoveById(id);
        return NoContent();
    }

    [HttpPut("{id}/assign-user/{userId}")]
    public async Task<IActionResult> AssignUser(
        [FromRoute] int id, [FromRoute] int userId)
    {
        if(!await _unitOfWork.Users.Exists(userId))
        {
            return UserNotFound(userId);
        }
        Map? map = await _unitOfWork.Maps.GetById(id);
        if(map is null)
        {
            return MapNotFound(id);
        }
        map.UserId = userId;
        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("{id}/features")]
    public async Task<IActionResult> GetFeatures([FromRoute] int id)
    {
        if(!await _unitOfWork.Maps.Exists(id))
        {
            return MapNotFound(id);
        }
        var features = await _unitOfWork.Maps.GetFeaturesById(id);
        return Ok(features.Select(FeatureDto.FromFeature));
    }
}
