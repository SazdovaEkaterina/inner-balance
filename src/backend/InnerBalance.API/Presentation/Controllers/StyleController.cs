using AutoMapper;
using InnerBalance.API.Business.Services;
using InnerBalance.API.Domain.DTO;
using InnerBalance.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnerBalance.API.Presentation.Controllers;

[ApiController]
[Route("api/yoga-styles")]
public class StyleController : ControllerBase
{
    private readonly IStyleService _styleService;
    private readonly IInnerBalanceService _innerBalanceService;
    private readonly IMapper _mapper;

    public StyleController(IStyleService styleService, IInnerBalanceService innerBalanceService, IMapper mapper)
    {
        _styleService = styleService;
        _innerBalanceService = innerBalanceService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StyleDto>>> GetRooms()
    {
        var styles = await _styleService.GetStylesAsync();
        
        var stylesDtos = styles.Select(style => _mapper.Map<StyleDto>(style)).ToList();
        
        return Ok(stylesDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StyleDto>> GetStyle([FromRoute] int id)
    {
        var style = await _styleService.GetStyleAsync(id);

        if (style == null)
        {
            return NotFound();
        }

        var styleDto = _mapper.Map<StyleDto>(style);
        return Ok(styleDto);
    }
    
    [HttpPost("add")]
    public async Task<ActionResult<StyleDto>> Create([FromBody] StyleDto styleDto)
    {
        var style = _mapper.Map<Style>(styleDto);

        _styleService.AddStyle(style);

        if (!await _innerBalanceService.SaveChangesAsync())
        {
            return BadRequest();
        }

        return Ok();
    }
    
    [HttpPut("{id}/edit")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] StyleDto styleDto)
    {
        var room = await _styleService.GetStyleAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        _mapper.Map(styleDto, room);
        await _innerBalanceService.SaveChangesAsync();

        return Ok(_mapper.Map<StyleDto>(room));
    }
    
    [HttpDelete("{id}/delete")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var style = await _styleService.GetStyleAsync(id);

        if (style == null)
        {
            return NotFound();
        }
        
        _styleService.DeleteStyle(style);
        await _innerBalanceService.SaveChangesAsync();
        
        return Ok();
    }
}