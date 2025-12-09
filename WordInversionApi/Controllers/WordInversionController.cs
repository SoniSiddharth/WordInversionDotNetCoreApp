using Microsoft.AspNetCore.Mvc;
using WordInversionApi.Services;

namespace WordInversionApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordInversionController : ControllerBase
{
    private readonly IWordInversionService _service;

    public WordInversionController(IWordInversionService service)
    {
        _service = service;
    }

    [HttpPost("invert")]
    public async Task<IActionResult> InvertWords([FromBody] string sentence)
    {
        var inverted = await _service.InvertWordsAsync(sentence);
        var record = await _service.SaveInversionAsync(sentence, inverted);

        return Ok(new
        {
            id = record.Id,
            request = record.RequestText,
            response = record.ResponseText
        });
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var records = await _service.GetAllAsync();
        return Ok(records);
    }

    [HttpGet("find/{word}")]
    public async Task<IActionResult> FindByWord(string word)
    {
        var records = await _service.FindByWordAsync(word);
        return Ok(records);
    }
}
