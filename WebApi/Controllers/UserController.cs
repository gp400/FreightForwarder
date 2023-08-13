using Business.Services.IAS;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetAll(int companyId)
        {
            try
            {
                var users = await userService.GetAll(companyId);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new List<string> { ex.Message });
            }
        }
    }
}
