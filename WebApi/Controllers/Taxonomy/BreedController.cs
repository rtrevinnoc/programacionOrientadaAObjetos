using AutoMapper;
using Core;
using Core.Domain.Taxonomy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApi.Mapping.Resources.Taxonomy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers.Taxonomy
{
    [ApiController]
    [Route("Breeds")]
    public class BreedsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BreedsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBreed([FromBody] SaveBreedResource saveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var specie = await _unitOfWork.Species.GetAsync(saveResource.SpecieId);
            if (specie == null)
                return BadRequest("La SpecieId proporcionada no es válida.");

            var breed = new Breed(
                saveResource.Name,
                saveResource.SpecieId
            );

            await _unitOfWork.Breeds.AddAsync(breed);
            await _unitOfWork.CompleteAsync();

            breed.Specie = specie;
            var resource = _mapper.Map<Breed, BreedResource>(breed);
            return Ok(resource);
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetBreeds()
        {
            var breeds = await _unitOfWork.Breeds.GetAllWithSpecieAsync();
            var resources = _mapper.Map<IEnumerable<Breed>, IEnumerable<BreedResource>>(breeds);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBreed(Guid id)
        {
            var breed = await _unitOfWork.Breeds.GetByIdWithSpecieAsync(id);
            if (breed == null)
                return NotFound("Breed no encontrada.");

            var resource = _mapper.Map<Breed, BreedResource>(breed);
            return Ok(resource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBreed(Guid id, [FromBody] SaveBreedResource saveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var breedToUpdate = await _unitOfWork.Breeds.GetAsync(id);
            if (breedToUpdate == null)
                return NotFound("Breed no encontrada.");
            
            var specie = await _unitOfWork.Species.GetAsync(saveResource.SpecieId);
            if (specie == null)
                return BadRequest("La SpecieId proporcionada no es válida.");

            breedToUpdate.Name = saveResource.Name;
            breedToUpdate.SpecieId = saveResource.SpecieId;
            
            await _unitOfWork.CompleteAsync();

            breedToUpdate.Specie = specie;
            var resource = _mapper.Map<Breed, BreedResource>(breedToUpdate);
            return Ok(resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(Guid id)
        {
            var breed = await _unitOfWork.Breeds.GetAsync(id);
            if (breed == null)
                return NotFound("Breed no encontrada.");

            _unitOfWork.Breeds.Remove(breed);
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Breed, BreedResource>(breed);
            return Ok(resource);
        }
    }
}