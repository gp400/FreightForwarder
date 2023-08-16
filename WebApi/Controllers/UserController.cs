using Business.DTOs.IAS;
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

        [HttpGet("{companyId}/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await userService.GetById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new List<string> { ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(UserDto userDto)
        {
            try
            {
                var result = await userService.Insert(userDto);
                return StatusCode(result.GetType().GetProperty("code").GetValue(result), result.GetType().GetProperty("response").GetValue(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new List<string> { ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            try
            {
                var result = await userService.Update(userDto);
                return StatusCode(result.GetType().GetProperty("code").GetValue(result), result.GetType().GetProperty("response").GetValue(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new List<string> { ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await userService.Delete(id);
                return StatusCode(result.GetType().GetProperty("code").GetValue(result), result.GetType().GetProperty("response").GetValue(result));
            }
            catch (Exception ex)
            {
                return BadRequest(new List<string> { ex.Message });
            }
        }
    }
}
