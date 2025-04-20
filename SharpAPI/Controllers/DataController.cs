using Microsoft.AspNetCore.Mvc;
using SharpAPI.Models;
using SharpAPI.Services;

namespace SharpAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly DataService _dataService;

    public DataController(DataService dataService)
    {
        _dataService = dataService;
    }

    [HttpPost]
    public async Task<IActionResult> PostData([FromBody] DataDTO dto)
    {
        try
        {
            var result = await _dataService.ProcessDataAsync(dto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}