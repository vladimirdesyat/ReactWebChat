using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;
using webapi.Models;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }
    [HttpPost("Send")]
    public async Task<ActionResult<string>> SendMessage([FromBody] Chat input)
    {
        try
        {
            if (string.IsNullOrEmpty(input?.Text))
            {
                return BadRequest("Input text is empty.");
            }

            var botResponse = await _chatService.ProcessUserMessageAsync(input.Text);

            Console.WriteLine($"User message: {input.Text}");
            Console.WriteLine($"Bot response: {botResponse}");

            return Ok(botResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
    [HttpGet("ChatbotAnswer")]
    public async Task<ActionResult<string>> GetChatbotAnswer()
    {
        try
        {
            var botResponse = await _chatService.GetChatbotResponseAsync();

            if (string.IsNullOrEmpty(botResponse))
            {
                return NotFound("Chatbot's response not found.");
            }

            return Ok(botResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
