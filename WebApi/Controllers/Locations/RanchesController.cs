using AutoMapper;
using Core;
using Core.Domain.Locations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApi.Mapping.Resources.Locations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers.Locations
{
    [ApiController]
    [Route("Ranches")]
    public class RanchesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RanchesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRanch([FromBody] SaveRanchResource saveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rancher = await _unitOfWork.Ranchers.GetAsync(saveResource.RancherId);
            if (rancher == null)
            {
                return BadRequest("El ID del Rancher proporcionado no es válido.");
            }

            var ranch = new Ranch(
                Guid.NewGuid(),
                saveResource.Name,
                saveResource.Location,
                saveResource.RancherId
            );

            await _unitOfWork.Ranches.AddAsync(ranch);
            await _unitOfWork.CompleteAsync();

            ranch.Rancher = rancher; 
            var resource = _mapper.Map<Ranch, RanchResource>(ranch);
            return Ok(resource);
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetRanches()
        {
            var ranches = await _unitOfWork.Ranches.GetAllWithRancherAsync(); 
            var resources = _mapper.Map<IEnumerable<Ranch>, IEnumerable<RanchResource>>(ranches);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRanchById(Guid id)
        {
            var ranch = await _unitOfWork.Ranches.GetByIdWithRancherAsync(id);
            if (ranch == null)
                return NotFound("Ranch no encontrado.");

            var resource = _mapper.Map<Ranch, RanchResource>(ranch);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRanch(Guid id, [FromBody] SaveRanchResource saveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ranchToUpdate = await _unitOfWork.Ranches.GetAsync(id);
            if (ranchToUpdate == null)
                return NotFound("Ranch no encontrado.");

            var rancher = await _unitOfWork.Ranchers.GetAsync(saveResource.RancherId);
            if (rancher == null)
            {
                return BadRequest("El ID del Rancher proporcionado no es válido.");
            }

            ranchToUpdate.Name = saveResource.Name;
            ranchToUpdate.Location = saveResource.Location;
            ranchToUpdate.RancherId = saveResource.RancherId;

            await _unitOfWork.CompleteAsync();

            ranchToUpdate.Rancher = rancher;
            var resource = _mapper.Map<Ranch, RanchResource>(ranchToUpdate);
            return Ok(resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRanch(Guid id)
        {
            var ranch = await _unitOfWork.Ranches.GetAsync(id);
            if (ranch == null)
                return NotFound("Ranch no encontrado.");

            _unitOfWork.Ranches.Remove(ranch);
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Ranch, RanchResource>(ranch);
            return Ok(resource);
        }
    }
}