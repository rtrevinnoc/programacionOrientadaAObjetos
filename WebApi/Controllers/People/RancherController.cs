using AutoMapper;
using Core;
using Core.Domain.People;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Persistence.Persistence;
using WebApi.Mapping.Resources.People;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Controllers.People
{
    [ApiController]
    [Route("Ranchers")]
    public class RanchersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RanchersController(ProgramacionOrientadaAObjetosContext context, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
        }

        [HttpPost]
        [EnableQuery]
        public async Task<IActionResult> CreateRancher([FromBody] SaveRancherResource saveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingRancher = _unitOfWork.Ranchers.GetRancherByUsername(saveResource.Username);
            if (existingRancher != null)
            {
                return BadRequest("El nombre de usuario ya existe.");
            }


            var rancher = new Rancher(
                Guid.NewGuid(),
                saveResource.Name,
                saveResource.Username,
                saveResource.Password
            );

            await _unitOfWork.Ranchers.AddAsync(rancher);
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Rancher, RancherResource>(rancher);

            return Ok(resource);
        }
    }
}