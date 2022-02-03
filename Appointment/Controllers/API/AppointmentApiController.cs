using Appointment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Appointment.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentApiController : ControllerBase
    {
        readonly IAppointmentService _appointmentService;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly string loginUserId;
        readonly string role;

        public AppointmentApiController(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            //var role2 = HttpContext.User.FindFirstValue(ClaimTypes.Role);// Can access HttpContext directly actually
        }

        public IActionResult Index()
        {
            return Ok();
        }
       
    }
}
