using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[EnableCors("_myAllowSpecificOrigins")]

public class SendMessageController : ControllerBase
{
    private readonly SendMessageService _sendMessageService;

    public SendMessageController(SendMessageService sendMessageService)
    {
        _sendMessageService = sendMessageService;
    }

    [HttpPost("SendMessage")]
    [AllowAnonymous]
    public async Task<Response<SendMessageDto>> SendMessage(SendMessageDto sms)
    {
        return await _sendMessageService.SendMessage(sms);
    }

}