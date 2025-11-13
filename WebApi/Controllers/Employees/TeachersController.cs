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
using WebApi.Models.Helpers.Http;
using SystemClaim = System.Security.Claims.ClaimTypes;

namespace WebApi.Controllers.Employees;

[ApiController]
[Route("Teachers")]
public class TeachersController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordHasher<object> _hasher;

    public TeachersController(
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
    public IActionResult GetTeachers()
    {
        var teacher = _unitOfWork.Teachers.GetAll().ToList();

        var resource = _mapper.Map<List<Teacher>, List<TeacherResource>>(teacher);

        return Ok(resource);
    }

    // [HttpGet("count")]
    // public IActionResult GetEmployeeCount(ODataQueryOptions<Employee> options)
    // {
    //     var employees = _unitOfWork.Employees.GetAll().AsQueryable();
    //     employees = (IQueryable<Employee>)options.ApplyTo(employees);

    //     var resource = employees.ToList()?.Count ?? 0;

    //     return Ok(resource);
    // }

    [HttpGet("{id}")]
    [EnableQuery]
    public IActionResult GetTeacher(string id)
    {
        var teacher = _unitOfWork.Teachers.Get(id);
        if (teacher == null)
            return NotFound();

        var resource = _mapper.Map<Teacher, TeacherResource>(teacher);

        return Ok(resource);
    }

    [HttpPost]
    [EnableQuery]
    [Authorize]
    public async Task<IActionResult> CreateTeacher([FromBody] SaveTeacherResource saveTeacherResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var teacher = manager.CreateTeacher(Guid.NewGuid(), saveTeacherResource.Name);

        _unitOfWork.Teachers.Add(teacher);

        await _unitOfWork.CompleteAsync();

        teacher = await _unitOfWork.Teachers.GetAsync(teacher.Id);

        var resource = _mapper.Map<Teacher, TeacherResource>(teacher!);

        return Ok(resource);
    }

    [HttpPut]
    [EnableQuery]
    [Authorize]
    public IActionResult UpdateTeacher([FromBody] SaveTeacherResource saveTeacherResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var teacher = _unitOfWork.Teachers.Get(saveTeacherResource.Id);
        if (teacher == null)
            return NotFound();

        _mapper.Map(saveTeacherResource, teacher);

        _unitOfWork.Complete();

        teacher = _unitOfWork.Teachers.Get(teacher.Id);

        var resource = _mapper.Map<Teacher, TeacherResource>(teacher!);

        return Ok(resource);
    }

    [HttpDelete("{id}")]
    [EnableQuery]
    [Authorize]
    public IActionResult DeleteTeacher(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var teacher = _unitOfWork.Teachers.Get(id);
        if (teacher == null)
            return NotFound();

        _unitOfWork.Teachers.Remove(teacher);

        _unitOfWork.Complete();

        return Ok();
    }

    #endregion

    #region Schedule

    [HttpPut("{id}/Schedule")]
    [EnableQuery]
    [Authorize]
    public async Task<IActionResult> AssignScheduleAsync(Guid id, [FromBody] SaveScheduleResource saveScheduleResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var teacher = _unitOfWork.Teachers.Get(id);
        if (teacher == null)
            return NotFound("Teacher not found");

        var course = _unitOfWork.Courses.Get(saveScheduleResource.CourseId);
        if (course == null)
            return NotFound("Course not found");

        var classroom = _unitOfWork.Classrooms.Get(saveScheduleResource.ClassroomId);
        if (classroom == null)
            return NotFound("Classroom not found");

        var schedule = manager.AssignCourseToTeacher(teacher, course, classroom, saveScheduleResource.Duration);

        _unitOfWork.Schedules.Add(schedule);

        await _unitOfWork.CompleteAsync();

        schedule = await _unitOfWork.Schedules.GetAsync(schedule.Id);

        var resource = _mapper.Map<Schedule, ScheduleResource>(schedule!);

        return Ok(resource);
    }

    #endregion

}