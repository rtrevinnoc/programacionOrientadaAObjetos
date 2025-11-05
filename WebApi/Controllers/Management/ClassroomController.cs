using System.Net.Mime;
using System.Reflection;
using AutoMapper;
using Core;
using Core.Domain.Employees;
using Core.Domain.Management;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Persistence.Persistence;
using WebApi.Mapping.Resources.Employees;
using WebApi.Mapping.Resources.Management;
using WebApi.Models.Helpers.Http;
using SystemClaim = System.Security.Claims.ClaimTypes;

namespace WebApi.Controllers.Management;

[ApiController]
[Route("Classroom")]
public class ClassroomController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordHasher<object> _hasher;


    public ClassroomController(
        ProgramacionOrientadaAObjetosContext programacionOrientadaAObjetosContext,
        IMapper mapper
    )
    {
        _unitOfWork = new UnitOfWork(programacionOrientadaAObjetosContext);
        _mapper = mapper;
        _hasher = new PasswordHasher<object>();
    }

    #region CRUD

    [HttpGet]
    [EnableQuery]
    public IActionResult GetClassrooms()
    {
        var classrooms = _unitOfWork.Classrooms.GetAll().ToList();

        var resource = _mapper.Map<List<Classroom>, List<ClassroomResource>>(classrooms);

        return Ok(resource);
    }

    [HttpPost]
    [EnableQuery]
    [Authorize]
    public async Task<IActionResult> CreateClassroom([FromBody] SaveClassroomResource saveClassroomResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var classroom = _mapper.Map<SaveClassroomResource, Classroom>(saveClassroomResource);

        _unitOfWork.Classrooms.Add(classroom);
        _unitOfWork.Llaves.Add(classroom.Llave);
        classroom.Llave.ClassroomId = classroom.Id;

        await _unitOfWork.CompleteAsync();

        classroom = await _unitOfWork.Classrooms.GetAsync(classroom.Id);

        var resource = _mapper.Map<Classroom, ClassroomResource>(classroom!);

        return Ok(resource);
    }

    [HttpPut]
    [EnableQuery]
    [Authorize]
    public IActionResult UpdateClassroom([FromBody] SaveClassroomResource saveClassroomResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var classroom = _unitOfWork.Classrooms.Get(saveClassroomResource.Id!.Value);
        if (classroom == null)
            return NotFound();

        _mapper.Map(saveClassroomResource, classroom);

        _unitOfWork.Complete();

        classroom = _unitOfWork.Classrooms.Get(classroom.Id);

        var resource = _mapper.Map<Classroom, ClassroomResource>(classroom!);

        return Ok(resource);
    }

    [HttpDelete("{id}")]
    [EnableQuery]
    [Authorize]
    public IActionResult DeleteClassrooom(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var classroom = _unitOfWork.Classrooms.Get(id);
        if (classroom == null)
            return NotFound();

        _unitOfWork.Classrooms.Remove(classroom);

        _unitOfWork.Complete();

        return Ok();
    }

    #endregion

}