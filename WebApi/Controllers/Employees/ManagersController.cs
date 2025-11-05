using System.Reflection;
using AutoMapper;
using Core;
using Core.Domain.Documents;
using Core.Domain.Employees;
using Core.Domain.Management;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Persistence.Persistence;
using WebApi.Mapping.Resources.Documents;
using WebApi.Mapping.Resources.Employees;
using WebApi.Mapping.Resources.Management;
using SystemClaim = System.Security.Claims.ClaimTypes;

namespace WebApi.Controllers.Employees;

[ApiController]
[Route("Managers")]
public class ManagersController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordHasher<object> _hasher;


    public ManagersController(
        ProgramacionOrientadaAObjetosContext programacionOrientadaAObjetosContext,
        IMapper mapper
    )
    {
        _unitOfWork = new UnitOfWork(programacionOrientadaAObjetosContext);
        _mapper = mapper;
        _hasher = new PasswordHasher<object>();
    }

    #region CRUD

    // [HttpGet]
    // [EnableQuery]
    // public IActionResult GetManagers()
    // {
    //     var managers = _unitOfWork.Managers.GetAll().ToList();

    //     // var resource = _mapper.Map<List<Manager>, List<TeacherResource>>(managers);

    //     return Ok(resource);
    // }

    // [HttpGet("{id}")]
    // [EnableQuery]
    // public IActionResult GetTeacher(string id)
    // {
    //     var teacher = _unitOfWork.Teachers.Get(id);
    //     if (teacher == null)
    //         return NotFound();

    //     var resource = _mapper.Map<Teacher, TeacherResource>(teacher);

    //     return Ok(resource);
    // }

    [HttpPost]
    [EnableQuery]
    public async Task<IActionResult> CreateManager([FromBody] SaveManagerResource saveManagerResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var manager = _mapper.Map<SaveManagerResource, Manager>(saveManagerResource);
        manager.Name = saveManagerResource.Name;

        manager.Password = _hasher.HashPassword(null, saveManagerResource.Password);

        _unitOfWork.Managers.Add(manager);

        await _unitOfWork.CompleteAsync();

        manager = await _unitOfWork.Managers.GetAsync(manager.Id);

        var resource = _mapper.Map<Manager, ManagerResource>(manager!);

        return Ok(resource);
    }

    #endregion
}