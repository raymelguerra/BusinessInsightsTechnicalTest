using FizzBuzz.Infrastructure.Dtos;
using FizzBuzz.Infrastructure.Exceptions;
using FizzBuzz.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FizzBuzzController(IFizzBuzzService fizzBuzzService) : ControllerBase
{
    [HttpPost("generate")]
    public async Task<ActionResult<FizzBuzzResponse>> GenerateFizzBuzz([FromBody] FizzBuzzRequest request)
    {
        try
        {
            var result = await fizzBuzzService.GenerateAndSaveAsync(request.Start, request.Limit);
            return Ok(result);
        }
        catch (InvalidInputException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An unexpected error occurred." });
        }
    }
}
