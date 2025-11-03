using Microsoft.AspNetCore.Mvc;

namespace CartoLogger.WebApi.Controllers;

public abstract class CartoLoggerController : ControllerBase
{
    protected ObjectResult UserNotFound(int userId)
    { 
        return Problem(
            title: "Invalid user id",
            detail: $"invalid user id: {userId}",
            statusCode: StatusCodes.Status404NotFound
        );
    }

    protected ObjectResult MapNotFound(int mapId)
    {
        return Problem(
            title: "Invalid map id",
            detail: $"Unrecognized map id: {mapId}",
            statusCode: StatusCodes.Status404NotFound
        );
    }

    protected ObjectResult FeatureNotFound(int featureId)
    {
        return Problem(
            title: "Invalid feature id",
            detail: $"Unrecognized feature id: {featureId}",
            statusCode: StatusCodes.Status404NotFound
        );
    }
}
