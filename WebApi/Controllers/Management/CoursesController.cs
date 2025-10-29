using System.Net.Mime;
using System.Reflection;
using AutoMapper;
using Core;
using Core.Domain.Employees;
using Core.Domain.Management;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Persistence.Persistence;
using WebApi.Mapping.Resources.Employees;
using WebApi.Mapping.Resources.Management;
using SystemClaim = System.Security.Claims.ClaimTypes;

namespace WebApi.Controllers.Management;

[ApiController]
[Route("Courses")]
public class CoursesController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public CoursesController(
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
    public IActionResult GetCourses()
    {
        var courses = _unitOfWork.Courses.GetAll().ToList();

        var resource = _mapper.Map<List<Course>, List<CourseResource>>(courses);

        return Ok(resource);
    }

    [HttpPost]
    [EnableQuery]
    public async Task<IActionResult> CreateCourse([FromBody] SaveCourseResource saveCourseResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var course = _mapper.Map<SaveCourseResource, Course>(saveCourseResource);

        _unitOfWork.Courses.Add(course);

        await _unitOfWork.CompleteAsync();

        course = await _unitOfWork.Courses.GetAsync(course.Id);

        var resource = _mapper.Map<Course, CourseResource>(course!);

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

}