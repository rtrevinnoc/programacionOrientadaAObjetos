using AutoMapper;
using Core;
using Core.Domain.Taxonomy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Persistence.Persistence;
using WebApi.Mapping.Resources.Taxonomy;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WebApi.Controllers.Taxonomy
{
    [ApiController]
    [Route("Species")]
    public class SpeciesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SpeciesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetSpecies()
        {
            var species = await _unitOfWork.Species.GetAllAsync();
            var resources = _mapper.Map<IEnumerable<Specie>, IEnumerable<SpecieResource>>(species);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecieById(Guid id)
        {
            var specie = await _unitOfWork.Species.GetAsync(id);
            if (specie == null)
                return NotFound("Especie no encontrada.");

            var resource = _mapper.Map<Specie, SpecieResource>(specie);
            return Ok(resource);
        }

        // --- CREATE ---
        [HttpPost]
        public async Task<IActionResult> CreateSpecie([FromBody] SaveSpecieResource saveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var specie = _mapper.Map<SaveSpecieResource, Specie>(saveResource);
            
            // Asumimos que la entidad Specie genera su ID en el constructor
            // o que el mapeo lo maneja. Si no, añade: specie.Id = Guid.NewGuid();

            await _unitOfWork.Species.AddAsync(specie);
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Specie, SpecieResource>(specie);
            return Ok(resource);
        }

        // --- UPDATE ---
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpecie(Guid id, [FromBody] SaveSpecieResource saveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var specie = await _unitOfWork.Species.GetAsync(id);
            if (specie == null)
                return NotFound("Especie no encontrada.");

            _mapper.Map(saveResource, specie);
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Specie, SpecieResource>(specie);
            return Ok(resource);
        }

        // --- DELETE ---
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecie(Guid id)
        {
            var specie = await _unitOfWork.Species.GetAsync(id);
            if (specie == null)
                return NotFound("Especie no encontrada.");

            _unitOfWork.Species.Remove(specie);
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Specie, SpecieResource>(specie);
            return Ok(resource);
        }
    }
}