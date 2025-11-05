using System.Reflection;
using AutoMapper;
using Core;
using Core.Domain.Documents;
using Core.Domain.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Persistence.Persistence;
using WebApi.Mapping.Resources.Documents;
using WebApi.Mapping.Resources.Employees;
using WebApi.Models.Helpers.Http;
using SystemClaim = System.Security.Claims.ClaimTypes;

namespace WebApi.Controllers.Employees;

[ApiController]
[Route("Employees")]
public class EmployeesController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly PasswordHasher<object> _hasher;


    public EmployeesController(
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
    public IActionResult GetEmployees()
    {
        var employees = _unitOfWork.Employees.GetAll().ToList();

        var resource = _mapper.Map<List<Employee>, List<EmployeeResource>>(employees);

        return Ok(resource);
    }

    [HttpGet("count")]
    public IActionResult GetEmployeeCount(ODataQueryOptions<Employee> options)
    {
        var employees = _unitOfWork.Employees.GetAll().AsQueryable();
        employees = (IQueryable<Employee>)options.ApplyTo(employees);

        var resource = employees.ToList()?.Count ?? 0;

        return Ok(resource);
    }

    [HttpGet("{id}")]
    [EnableQuery]
    public IActionResult GetEmployee(string id)
    {
        var employee = _unitOfWork.Employees.Get(id);
        if (employee == null)
            return NotFound();

        var resource = _mapper.Map<Employee, EmployeeResource>(employee);

        return Ok(resource);
    }

    [HttpPost]
    [EnableQuery]
    [Authorize]
    public async Task<IActionResult> CreateEmployee([FromBody] SaveEmployeeResource saveEmployeeResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var employee = _mapper.Map<SaveEmployeeResource, Employee>(saveEmployeeResource);

        _unitOfWork.Employees.Add(employee);

        await _unitOfWork.CompleteAsync();

        employee = await _unitOfWork.Employees.GetAsync(employee.Id);

        var resource = _mapper.Map<Employee, EmployeeResource>(employee!);

        return Ok(resource);
    }

    [HttpPut]
    [EnableQuery]
    [Authorize]
    public IActionResult UpdateEmployee([FromBody] SaveEmployeeResource saveEmployeeResource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var employee = _unitOfWork.Employees.Get(saveEmployeeResource.Id);
        if (employee == null)
            return NotFound();

        _mapper.Map(saveEmployeeResource, employee);

        _unitOfWork.Complete();

        employee = _unitOfWork.Employees.Get(employee.Id);

        var resource = _mapper.Map<Employee, EmployeeResource>(employee!);

        return Ok(resource);
    }

    [HttpDelete("{id}")]
    [EnableQuery]
    [Authorize]
    public IActionResult DeleteEmployee(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var employee = _unitOfWork.Employees.Get(id);
        if (employee == null)
            return NotFound();

        _unitOfWork.Employees.Remove(employee);

        _unitOfWork.Complete();

        return Ok();
    }

    #endregion

    #region Documents

    [HttpPut("{id}/Document")]
    [EnableQuery]
    [Authorize]
    public IActionResult UploadDocument(string id, IFormFile file)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var httpBasicAuth = new HttpBasicAuth(HttpContext);
        var manager = _unitOfWork.Managers.GetManagerByUsername(httpBasicAuth.UserName);
        if (manager.SignIn(_hasher, httpBasicAuth.Password) != PasswordVerificationResult.Success)
            return Unauthorized();

        var employee = _unitOfWork.Employees.Get(id);
        if (employee == null)
            return NotFound();

        Document document = manager.AssignDocumentToEmployee(employee, file);

        _unitOfWork.Documents.Add(document);
        _unitOfWork.Complete();

        document = _unitOfWork.Documents.Get(document.Id);

        var resource = _mapper.Map<Document, DocumentResource>(document);

        return Ok(resource);
    }

    #endregion

}