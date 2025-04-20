using Microsoft.AspNetCore.Mvc;
using SharpAPI.Models;
using SharpAPI.Services;

namespace SharpAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataController : ControllerBase
{
    private readonly DataService _dataService;
    private readonly PythonSenderService _senderService;

    public DataController(DataService dataService, PythonSenderService senderService)
    {
        _dataService = dataService;
        _senderService = senderService;
    }

    [HttpPost]
    public async Task<IActionResult> PostData([FromBody] DataDTO dto)
    {
        try
        {
            var result = await _dataService.ProcessDataAsync(dto);
            await _senderService.SendDataAsync(dto);
            return Ok(new { Message = "Данные переданыв в Python-сервис" });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}