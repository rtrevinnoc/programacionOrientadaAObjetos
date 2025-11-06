using AutoMapper;
using Core;
using Core.Domain.Locations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Persistence.Persistence;
using WebApi.Mapping.Resources.Locations;
using WebApi.Models.Helpers.Http;

namespace WebApi.Controllers.Locations
{
    [ApiController]
    [Route("Corrals")]
    public class CorralsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PasswordHasher<object> _hasher;

        public CorralsController(ProgramacionOrientadaAObjetosContext context, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
            _hasher = new PasswordHasher<object>();
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetCorrals()
        {
            var corrals = _unitOfWork.Corrals.GetAll().ToList();
            var resource = _mapper.Map<List<Corral>, List<CorralResource>>(corrals);
            return Ok(resource);
        }

        [HttpPost]
        [EnableQuery]
        [Authorize]
        public async Task<IActionResult> CreateCorral([FromBody] SaveCorralResource saveResource)
        {
            var httpBasicAuth = new HttpBasicAuth(HttpContext);
            var rancher = _unitOfWork.Ranchers.GetRancherByUsername(httpBasicAuth.UserName);
            if (rancher == null || rancher.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
                return Unauthorized();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var corral = _mapper.Map<SaveCorralResource, Corral>(saveResource);
            corral.IdCorral = Guid.NewGuid();

            _unitOfWork.Corrals.Add(corral);
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Corral, CorralResource>(corral);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        [EnableQuery]
        [Authorize]
        public async Task<IActionResult> UpdateCorral(Guid id, [FromBody] SaveCorralResource saveResource)
        {
            var httpBasicAuth = new HttpBasicAuth(HttpContext);
            var rancher = _unitOfWork.Ranchers.GetRancherByUsername(httpBasicAuth.UserName);
            if (rancher.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
                return Unauthorized();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var corral = await _unitOfWork.Corrals.GetAsync(id);
            if (corral == null)
                return NotFound();

            _mapper.Map(saveResource, corral);
            
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Corral, CorralResource>(corral);
            return Ok(resource);
        }

        [HttpDelete("{id}")]
        [EnableQuery]
        [Authorize]
        public async Task<IActionResult> DeleteCorral(Guid id)
        {
            var httpBasicAuth = new HttpBasicAuth(HttpContext);
            var rancher = _unitOfWork.Ranchers.GetRancherByUsername(httpBasicAuth.UserName);
            if (rancher.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
                return Unauthorized();
            var corral = await _unitOfWork.Corrals.GetAsync(id);
            if (corral == null)
                return NotFound();

            _unitOfWork.Corrals.Remove(corral);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}