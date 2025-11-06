using System.Reflection;
using AutoMapper;
using Core;
using Core.Domain.Livestock;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Persistence.Persistence;
using WebApi.Mapping.Resources.Livestock; 
using SystemClaim = System.Security.Claims.ClaimTypes;

namespace WebApi.Controllers.Livestock;

[ApiController]
[Route("Livestock/Livestock")]
public class LivestockController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LivestockController(
        ProgramacionOrientadaAObjetosContext programacionOrientadaAObjetosContext,
        IMapper mapper
    )
    {
        _unitOfWork = new UnitOfWork(programacionOrientadaAObjetosContext);
        _mapper = mapper;
    }

    #region CRUD

    [HttpGet]
    [EnableQuery]
    public IActionResult GetLivestock()
    {
        var livestock = _unitOfWork.Livestock.GetAll().ToList();
        var resource = _mapper.Map<List<Animal>, List<AnimalResource>>(livestock);
        return Ok(resource);
    }

    [HttpGet("count")]
    public IActionResult GetAnimalCount(ODataQueryOptions<Animal> options)
    {
        var livestock = _unitOfWork.Livestock.GetAll().AsQueryable();
        livestock = (IQueryable<Animal>)options.ApplyTo(livestock);
        var resource = livestock.ToList()?.Count ?? 0;
        return Ok(resource);
    }

    [HttpGet("{id:guid}")]
    [EnableQuery]
    public IActionResult GetAnimal(Guid id)
    {
        var animal = _unitOfWork.Livestock.Get(id);
        if (animal == null)
            return NotFound();

        var resource = _mapper.Map<Animal, AnimalResource>(animal);
        return Ok(resource);
    }

    
    [HttpPost("horse")]
    [EnableQuery]
    public async Task<IActionResult> CreateHorse([FromBody] SaveHorseResource saveHorseResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var horse = _mapper.Map<SaveHorseResource, Horse>(saveHorseResource);

        _unitOfWork.Livestock.Add(horse);
        await _unitOfWork.CompleteAsync();

        var animal = await _unitOfWork.Livestock.GetAsync(horse.IdRegistration);
        var resource = _mapper.Map<Horse, HorseResource>((Horse)animal!);

        return Ok(resource);
    }

    [HttpPost("goat")]
    [EnableQuery]
    public async Task<IActionResult> CreateGoat([FromBody] SaveGoatResource saveGoatResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var goat = _mapper.Map<SaveGoatResource, Goat>(saveGoatResource);

        _unitOfWork.Livestock.Add(goat);
        await _unitOfWork.CompleteAsync();
        
        var animal = await _unitOfWork.Livestock.GetAsync(goat.IdRegistration);
        var resource = _mapper.Map<Goat, GoatResource>((Goat)animal!);

        return Ok(resource);
    }

    
    [HttpPut("horse/{id:guid}")]
    [EnableQuery]
    public IActionResult UpdateHorse(Guid id, [FromBody] SaveHorseResource saveHorseResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var animalInDb = _unitOfWork.Livestock.Get(id);
        if (animalInDb == null)
            return NotFound();

        if (animalInDb is not Horse horseInDb)
        {
            return BadRequest("El animal con este ID no es un Horse.");
        }

        _mapper.Map(saveHorseResource, horseInDb);

        _unitOfWork.Complete();

        var resource = _mapper.Map<Animal, AnimalResource>(horseInDb);
        return Ok(resource);
    }

    [HttpPut("goat/{id:guid}")]
    [EnableQuery]
    public IActionResult UpdateGoat(Guid id, [FromBody] SaveGoatResource saveGoatResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var animalInDb = _unitOfWork.Livestock.Get(id);
        if (animalInDb == null)
            return NotFound();

        if (animalInDb is not Goat goatInDb)
        {
            return BadRequest("El animal con este ID no es una Goat.");
        }

        _mapper.Map(saveGoatResource, goatInDb);
        _unitOfWork.Complete();
        
        var resource = _mapper.Map<Animal, AnimalResource>(goatInDb);
        return Ok(resource);
    }


    [HttpDelete("{id:guid}")]
    [EnableQuery]
    public IActionResult DeleteAnimal(Guid id)
    {
        var animal = _unitOfWork.Livestock.Get(id);
        if (animal == null)
            return NotFound();

        _unitOfWork.Livestock.Remove(animal);
        _unitOfWork.Complete();

        var resource = _mapper.Map<Animal, AnimalResource>(animal!);
        return Ok(resource);
    }

    #endregion

    #region Business Logic

    [HttpPut("{animalId}/AssignCorral")]
    [EnableQuery]
    public async Task<IActionResult> AssignCorral(Guid animalId, [FromBody] WebApi.Mapping.Resources.Locations.AssignCorralResource assignResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var animal = await _unitOfWork.Livestock.GetAsync(animalId);
        if (animal == null)
            return NotFound("Animal no encontrado.");

        var corral = await _unitOfWork.Corrals.GetAsync(assignResource.CorralId);
        if (corral == null)
            return NotFound("Corral no encontrado.");


        var animalsInCorral = await _unitOfWork.Livestock.FindAsync(a => a.CorralId == corral.IdCorral);
        if (animalsInCorral.Count() >= corral.Capacity)
        {
            return BadRequest("El corral esta lleno. No se puede asignar el animal.");
        }

        animal.CorralId = corral.IdCorral;

        await _unitOfWork.CompleteAsync();

        var animalResource = _mapper.Map<Animal, AnimalResource>(animal);
        return Ok(animalResource);
    }

    #endregion
}