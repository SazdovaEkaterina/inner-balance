using InnerBalance.API.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace InnerBalance.API.Presentation.Controllers;

[ApiController]
[Route("api/yoga-styles")]
public class StyleController : ControllerBase
{
    private readonly IStyleService _styleService;

    public StyleController(IStyleService styleService)
    {
        _styleService = styleService;
    }
}