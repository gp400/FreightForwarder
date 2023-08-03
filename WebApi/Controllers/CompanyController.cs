using Business.DTOs.IAS;
using Business.Services.IAS;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly CompanyService companyService;

        public CompanyController(CompanyService _companyService)
        {
            companyService = _companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var companies = await companyService.GetAll();
                return Ok(companies);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var company = await companyService.GetById(id);
                if (company == null)
                {
                    return NotFound();
                }
                return Ok(company);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CompanyDto companyDto)
        {
            try
            {
                var result = await companyService.Insert(companyDto);
                return StatusCode(result.GetType().GetProperty("code").GetValue(result), result.GetType().GetProperty("response").GetValue(result));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyDto companyDto)
        {
            try
            {
                var result = await companyService.Update(companyDto);
                return StatusCode(result.GetType().GetProperty("code").GetValue(result), result.GetType().GetProperty("response").GetValue(result));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await companyService.Delete(id);
                return StatusCode(result.GetType().GetProperty("code").GetValue(result), result.GetType().GetProperty("response").GetValue(result));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
