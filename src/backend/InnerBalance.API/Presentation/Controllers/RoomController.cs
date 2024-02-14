using AutoMapper;
using InnerBalance.API.Business.Services;
using InnerBalance.API.Domain.DTO;
using InnerBalance.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace InnerBalance.API.Presentation.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    private readonly IInnerBalanceService _innerBalanceService;
    private readonly IMapper _mapper;

    public RoomController(IRoomService roomService, IInnerBalanceService innerBalanceService, IMapper mapper)
    {
        _roomService = roomService;
        _innerBalanceService = innerBalanceService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
    {
        var rooms = await _roomService.GetRoomsAsync();
        
        var roomsDtos = rooms.Select(room => _mapper.Map<RoomDto>(room)).ToList();
        
        return Ok(roomsDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomDto>> GetRoom([FromRoute] int id)
    {
        var room = await _roomService.GetRoomAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        var roomDto = _mapper.Map<RoomDto>(room);
        return Ok(roomDto);
    }
    
    [HttpPost("add")]
    public async Task<ActionResult<RoomDto>> Create([FromBody] RoomDto roomDto)
    {
        var room = _mapper.Map<Room>(roomDto);

        _roomService.AddRoom(room);

        if (!await _innerBalanceService.SaveChangesAsync())
        {
            return BadRequest();
        }

        return Ok();
    }
    
    [HttpPut("{id}/edit")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] RoomDto roomDto)
    {
        var room = await _roomService.GetRoomAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        _mapper.Map(roomDto, room);
        await _innerBalanceService.SaveChangesAsync();

        return Ok(_mapper.Map<RoomDto>(room));
    }
    
    [HttpDelete("{id}/delete")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var room = await _roomService.GetRoomAsync(id);

        if (room == null)
        {
            return NotFound();
        }
        
        _roomService.DeleteRoom(room);
        await _innerBalanceService.SaveChangesAsync();
        
        return Ok();
    }
}