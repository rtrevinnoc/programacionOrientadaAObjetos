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
[Route("Teachers")]
public class TeachersController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public TeachersController(
        ProgramacionOrientadaAObjetosContext programacionOrientadaAObjetosContext,
        IMapper mapper
    )
    {
        _unitOfWork = new UnitOfWork(programacionOrientadaAObjetosContext);
        _mapper = mapper;
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

    // [HttpPut]
    // [EnableQuery]
    // public IActionResult UpdateEmployee([FromBody] SaveEmployeeResource saveEmployeeResource)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest(ModelState);

    //     var employee = _unitOfWork.Employees.Get(saveEmployeeResource.Id);
    //     if (employee == null)
    //         return NotFound();

    //     _mapper.Map(saveEmployeeResource, employee);

    //     _unitOfWork.Complete();

    //     employee = _unitOfWork.Employees.Get(employee.Id);

    //     var resource = _mapper.Map<Employee, EmployeeResource>(employee!);

    //     return Ok(resource);
    // }

    // [HttpDelete("{id}")]
    // [EnableQuery]
    // public IActionResult DeleteEmployee(string id)
    // {
    //     var employee = _unitOfWork.Employees.Get(id);
    //     if (employee == null)
    //         return NotFound();

    //     _unitOfWork.Employees.Remove(employee);

    //     _unitOfWork.Complete();

    //     return Ok();
    // }

    #endregion

    #region Schedule

    [HttpPut("{id}/Schedule")]
    [EnableQuery]
    public async Task<IActionResult> AssignScheduleAsync(string id, [FromBody] SaveScheduleResource saveScheduleResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var teacher = _unitOfWork.Teachers.Get(id);
        if (teacher == null)
            return NotFound();

        var schedule = _mapper.Map<SaveScheduleResource, Schedule>(saveScheduleResource);
        schedule.TeacherId = teacher.Id;

        _unitOfWork.Schedules.Add(schedule);

        await _unitOfWork.CompleteAsync();

        schedule = await _unitOfWork.Schedules.GetAsync(schedule.Id);

        var resource = _mapper.Map<Schedule, ScheduleResource>(schedule!);

        // Document document = new Document
        // {
        //     Id = Guid.NewGuid(),
        //     OwnerId = employee.Id,
        //     MimeType = file.ContentType,
        //     Name = file.FileName
        // };
        // // document.Content =

        // using (var ms = new MemoryStream())
        // {
        //     file.CopyTo(ms);
        //     document.Content = ms.ToArray();
        // }

        // _unitOfWork.Documents.Add(document);
        // _unitOfWork.Complete();

        // document = _unitOfWork.Documents.Get(document.Id);

        // var resource = _mapper.Map<Document, DocumentResource>(document);

        return Ok(resource);
    }

    #endregion

}