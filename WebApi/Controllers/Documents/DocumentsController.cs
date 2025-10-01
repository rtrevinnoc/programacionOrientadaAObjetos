using System.Reflection;
using AutoMapper;
using Core;
using Core.Domain.Documents;
using Core.Domain.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Persistence.Persistence;
using WebApi.Mapping.Resources.Documents;
using WebApi.Mapping.Resources.Employees;
using SystemClaim = System.Security.Claims.ClaimTypes;

namespace WebApi.Controllers.Documents;

[ApiController]
[Route("Documents")]
public class DocumentsController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public DocumentsController(
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
    public IActionResult GetDocuments()
    {
        var documents = _unitOfWork.Documents.GetAll().ToList();

        var resource = _mapper.Map<List<Document>, List<DocumentResource>>(documents);

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
    public IActionResult GetDocument(Guid id)
    {
        var document = _unitOfWork.Documents.Get(id);
        if (document == null)
            return NotFound();

        var resource = _mapper.Map<Document, DocumentResource>(document);

        return Ok(resource);
    }

    // [HttpPost]
    // [EnableQuery]
    // public async Task<IActionResult> CreateEmployee([FromBody] SaveEmployeeResource saveEmployeeResource)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest(ModelState);

    //     var employee = _mapper.Map<SaveEmployeeResource, Employee>(saveEmployeeResource);

    //     _unitOfWork.Employees.Add(employee);

    //     await _unitOfWork.CompleteAsync();

    //     employee = await _unitOfWork.Employees.GetAsync(employee.Id);

    //     var resource = _mapper.Map<Employee, EmployeeResource>(employee!);

    //     return Ok(resource);
    // }

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