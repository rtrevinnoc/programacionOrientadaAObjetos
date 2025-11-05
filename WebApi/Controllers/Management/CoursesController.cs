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
[Route("Courses")]
public class CoursesController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordHasher<object> _hasher;

    public CoursesController(
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

        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var course = manager.CreateCourse(Guid.NewGuid(), saveCourseResource.Name);

        _unitOfWork.Courses.Add(course);

        await _unitOfWork.CompleteAsync();

        course = await _unitOfWork.Courses.GetAsync(course.Id);

        var resource = _mapper.Map<Course, CourseResource>(course!);

        return Ok(resource);
    }

    [HttpPut]
    [EnableQuery]
    [Authorize]
    public IActionResult UpdateCourse([FromBody] SaveCourseResource saveCourseResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var course = _unitOfWork.Courses.Get(saveCourseResource.Id!.Value);
        if (course == null)
            return NotFound();

        _mapper.Map(saveCourseResource, course);

        _unitOfWork.Complete();

        course = _unitOfWork.Courses.Get(course.Id);

        var resource = _mapper.Map<Course, CourseResource>(course!);

        return Ok(resource);
    }

    [HttpDelete("{id}")]
    [EnableQuery]
    [Authorize]
    public IActionResult DeleteCourse(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var course = _unitOfWork.Courses.Get(id);
        if (course == null)
            return NotFound();

        _unitOfWork.Courses.Remove(course);

        _unitOfWork.Complete();

        return Ok();
    }

    #endregion

}