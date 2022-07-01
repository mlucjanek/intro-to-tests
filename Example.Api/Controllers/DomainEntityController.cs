using Example.Application.Dto;
using Example.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DomainEntityController : ControllerBase
{
    private readonly IDomainEntityService _service;

    public DomainEntityController(IDomainEntityService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Set([FromBody] DomainEntityDto template)
    {
        var addedItem = await _service.AddNew(template);

        return Ok(addedItem);
    }

    [HttpGet]
    public async Task<IEnumerable<DomainEntityDto>> Get()
    {
        return await _service.GetAllTemplates();
    }
}
