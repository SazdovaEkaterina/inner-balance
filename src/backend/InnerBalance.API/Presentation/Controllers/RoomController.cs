using InnerBalance.API.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnerBalance.API.Presentation.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }
}