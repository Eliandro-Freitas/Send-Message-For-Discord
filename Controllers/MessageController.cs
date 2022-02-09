using Microsoft.AspNetCore.Mvc;

namespace LogandoNoDiscord.Controllers;

public class MessageController : ControllerBase
{
    private readonly ILogger<MessageController> _logger;

    public MessageController(ILogger<MessageController> logger)
    {
        _logger = logger;
    }

    [HttpGet("v1/message")]
    public void Get()
    {
        _logger.LogInformation("Ol�! Voc� recebeu uma mensagem pelo Discord.");
    }
}