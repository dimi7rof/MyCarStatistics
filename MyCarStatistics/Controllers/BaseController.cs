using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCarStatistics.Contracts;
using MyCarStatistics.Data.Models.Account;

namespace MyCarStatistics.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
        
    }
}
