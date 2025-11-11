using AutoMapper;
using Core;
using Core.Domain.Locations;
using Core.Domain.People;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApi.Mapping.Resources.Locations;
using WebApi.Models.Helpers.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;

namespace WebApi.Controllers.Locations
{
    [ApiController]
    [Route("Corrals")]
    public class CorralsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PasswordHasher<object> _hasher;

        public CorralsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _hasher = new PasswordHasher<object>();
        }

        private async Task<Rancher?> GetAuthenticatedRancherAsync()
        {
            var httpBasicAuth = new HttpBasicAuth(HttpContext);
            if (string.IsNullOrEmpty(httpBasicAuth.UserName))
                return null;

            var rancher = await _unitOfWork.Ranchers.GetRancherByUsernameAsync(httpBasicAuth.UserName);

            if (rancher == null || rancher.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
                return null;

            return rancher;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetCorrals()
        {
            var corrals = await _unitOfWork.Corrals.GetAllWithRanchAsync();
            var resources = _mapper.Map<IEnumerable<Corral>, IEnumerable<CorralResource>>(corrals);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCorralById(Guid id)
        {
            var corral = await _unitOfWork.Corrals.GetByIdWithRanchAsync(id);
            if (corral == null)
                return NotFound("Corral no encontrado.");

            var resource = _mapper.Map<Corral, CorralResource>(corral);
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCorral([FromBody] SaveCorralResource saveResource)
        {
            var rancher = await GetAuthenticatedRancherAsync();
            if (rancher == null)
                return Unauthorized();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ranch = await _unitOfWork.Ranches.GetAsync(saveResource.RanchId);
            if (ranch == null || ranch.RancherId != rancher.Id)
                return BadRequest("El RanchId no es válido o no te pertenece.");

            var corral = _mapper.Map<SaveCorralResource, Corral>(saveResource);

            await _unitOfWork.Corrals.AddAsync(corral);
            await _unitOfWork.CompleteAsync();

            corral.Ranch = ranch;
            var resource = _mapper.Map<Corral, CorralResource>(corral);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCorral(Guid id, [FromBody] SaveCorralResource saveResource)
        {
            var rancher = await GetAuthenticatedRancherAsync();
            if (rancher == null)
                return Unauthorized();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var corralToUpdate = await _unitOfWork.Corrals.GetAsync(id);
            if (corralToUpdate == null)
                return NotFound("Corral no encontrado.");

            if (corralToUpdate.RanchId != rancher.Id)
                 return Forbid("No eres dueño de este corral.");
            
            var ranch = await _unitOfWork.Ranches.GetAsync(saveResource.RanchId);
            if (ranch == null || ranch.RancherId != rancher.Id)
                return BadRequest("El RanchId no es válido o no te pertenece.");

            _mapper.Map(saveResource, corralToUpdate);
            await _unitOfWork.CompleteAsync();

            corralToUpdate.Ranch = ranch;
            var resource = _mapper.Map<Corral, CorralResource>(corralToUpdate);
            return Ok(resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorral(Guid id)
        {
            var rancher = await GetAuthenticatedRancherAsync();
            if (rancher == null)
                return Unauthorized();

            var corral = await _unitOfWork.Corrals.GetByIdWithRanchAsync(id); 
            if (corral == null)
                return NotFound("Corral no encontrado.");

            if (corral.Ranch.RancherId != rancher.Id)
                 return Forbid("No eres dueño de este corral.");

            _unitOfWork.Corrals.Remove(corral);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}