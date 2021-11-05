using Microsoft.AspNetCore.Mvc;

namespace DiskUsageUtility.Web.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        
    }
}