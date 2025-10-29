using System.Reflection;
using AutoMapper;
using Core;
using Core.Domain.Documents;
using Core.Domain.Employees;
using Core.Domain.Management;
using Microsoft.AspNetCore.Authorization;
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


    public ManagersController(
        ProgramacionOrientadaAObjetosContext programacionOrientadaAObjetosContext,
        IMapper mapper
    )
    {
        _unitOfWork = new UnitOfWork(programacionOrientadaAObjetosContext);
        _mapper = mapper;
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
    public async Task<IActionResult> CreateTeacher([FromBody] SaveTeacherResource saveTeacherResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var teacher = _mapper.Map<SaveTeacherResource, Teacher>(saveTeacherResource);

        _unitOfWork.Teachers.Add(teacher);

        await _unitOfWork.CompleteAsync();

        teacher = await _unitOfWork.Teachers.GetAsync(teacher.Id);

        var resource = _mapper.Map<Teacher, TeacherResource>(teacher!);

        return Ok(resource);
    }

}