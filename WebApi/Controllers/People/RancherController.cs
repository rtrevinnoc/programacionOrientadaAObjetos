using AutoMapper;
using Core;
using Core.Domain.People;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Persistence.Persistence;
using WebApi.Mapping.Resources.People;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers.People
{
    [ApiController]
    [Route("Ranchers")]
    public class RanchersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RanchersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRancher([FromBody] SaveRancherResource saveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingRancher = await _unitOfWork.Ranchers.GetRancherByUsernameAsync(saveResource.Username);
            if (existingRancher != null)
            {
                return BadRequest("El nombre de usuario ya existe.");
            }

            var rancher = new Rancher(
                saveResource.Name,
                saveResource.Username,
                saveResource.Password
            );

            await _unitOfWork.Ranchers.AddAsync(rancher);
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Rancher, RancherResource>(rancher);

            return Ok(resource);
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetRanchers()
        {
            var ranchers = await _unitOfWork.Ranchers.GetAllAsync();
            var resources = _mapper.Map<IEnumerable<Rancher>, IEnumerable<RancherResource>>(ranchers);
            return Ok(resources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRancherById(Guid id)
        {
            var rancher = await _unitOfWork.Ranchers.GetAsync(id);
            if (rancher == null)
                return NotFound("Rancher no encontrado.");

            var resource = _mapper.Map<Rancher, RancherResource>(rancher);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRancher(Guid id, [FromBody] SaveRancherResource saveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var rancherToUpdate = await _unitOfWork.Ranchers.GetAsync(id);
            if (rancherToUpdate == null)
                return NotFound("Rancher no encontrado.");


            var existingRancherByUsername = await _unitOfWork.Ranchers.GetRancherByUsernameAsync(saveResource.Username);
            if (existingRancherByUsername != null && existingRancherByUsername.Id != id)
            {
                return BadRequest("El nombre de usuario ya existe.");
            }

            rancherToUpdate.Name = saveResource.Name;
            rancherToUpdate.Username = saveResource.Username;

            if (!string.IsNullOrEmpty(saveResource.Password))
            {
                var hasher = new PasswordHasher<Rancher>();
                rancherToUpdate.Password = hasher.HashPassword(rancherToUpdate, saveResource.Password);
            }

            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Rancher, RancherResource>(rancherToUpdate);
            return Ok(resource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRancher(Guid id)
        {
            var rancher = await _unitOfWork.Ranchers.GetAsync(id);
            if (rancher == null)
                return NotFound("Rancher no encontrado.");

            _unitOfWork.Ranchers.Remove(rancher);
            await _unitOfWork.CompleteAsync();

            var resource = _mapper.Map<Rancher, RancherResource>(rancher);
            return Ok(resource);
        }
    }
}