using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyCarStatistics.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
