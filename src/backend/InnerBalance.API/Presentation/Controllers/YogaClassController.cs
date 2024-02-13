using AutoMapper;
using InnerBalance.API.Business.Services;
using InnerBalance.API.Domain.DTO;
using InnerBalance.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnerBalance.API.Presentation.Controllers;

[ApiController]
[Route("api/yoga-classes")]
public class YogaClassController : ControllerBase
{
    private readonly IYogaClassService _yogaClassService;
    private readonly IInnerBalanceService _innerBalanceService;
    private readonly IMapper _mapper;

    public YogaClassController(IYogaClassService yogaClassService, IMapper mapper, IInnerBalanceService innerBalanceService)
    {
        _yogaClassService = yogaClassService;
        _mapper = mapper;
        _innerBalanceService = innerBalanceService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<YogaClassDto>>> GetYogaClasses()
    {
        var yogaClasses = await _yogaClassService.GetYogaClassesAsync();
        
        var yogaClassesDtos = yogaClasses.Select(yogaClass => _mapper.Map<YogaClassDto>(yogaClass)).ToList();
        
        return Ok(yogaClassesDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<YogaClass>> GetYogaClass([FromRoute] int id)
    {
        var yogaClass = await _yogaClassService.GetYogaClassAsync(id);

        if (yogaClass == null)
        {
            return NotFound();
        }

        var yogaClassDto = _mapper.Map<YogaClassDto>(yogaClass);
        return Ok(yogaClassDto);
    }
    
    [HttpPost("add")]
    public async Task<ActionResult<YogaClassDto>> Create([FromBody] YogaClassDto yogaClassDto)
    {
        var yogaClass = _mapper.Map<YogaClass>(yogaClassDto);

        _yogaClassService.AddYogaClass(yogaClass);

        if (!await _innerBalanceService.SaveChangesAsync())
        {
            return BadRequest();
        }

        return Ok();
    }
    
    [HttpPut("{id}/edit")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] YogaClassDto yogaClassDto)
    {
        var yogaClass = await _yogaClassService.GetYogaClassAsync(id);

        if (yogaClass == null)
        {
            return NotFound();
        }

        _mapper.Map(yogaClassDto, yogaClass);
        await _innerBalanceService.SaveChangesAsync();

        return Ok(_mapper.Map<YogaClassDto>(yogaClass));
    }
    
    [HttpDelete]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var yogaClass = await _yogaClassService.GetYogaClassAsync(id);

        if (yogaClass == null)
        {
            return NotFound();
        }
        
        _yogaClassService.DeleteYogaClass(yogaClass);
        await _innerBalanceService.SaveChangesAsync();
        
        return NoContent();
    }
}