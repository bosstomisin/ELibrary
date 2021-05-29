using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.MVC.Controllers.ApiControllers
{
    /// <summary>
    /// Base Api Controller
    /// </summary>
    [Authorize(AuthenticationSchemes="Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
