using System;
using System.Net;
using System.Threading.Tasks;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.Chats.CreateChat;
using SampleProject.Application.Chats.CreateChat.Dto.Requests;
using SampleProject.Application.Chats.CreateChat.Dto.Responses;
using SampleProject.Application.Chats.DeleteChat;
using SampleProject.Application.Chats.GetChat;
using SampleProject.Application.Chats.GetChat.Dto.Responses;
using SampleProject.Application.Chats.GetChats;
using SampleProject.Application.Chats.GetChats.Dto.Responses;
using SampleProject.Application.Chats.UpdateChat;
using SampleProject.Application.Chats.UpdateChat.Dto.Requests;

namespace SampleProject.API.Chats;

[Route("api/v1/chats")]
[ApiVersion("1.0")]
[ApiController]
[Authorize]
public class ChatsControllers : Controller
{
    private readonly IMediator _mediator;

    public ChatsControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create chat
    /// </summary>
    [HttpPost]
    [ProducesResponseType<CreateChatResponse>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateChat([FromBody] CreateChatRequest request)
    {
        var response = await _mediator.Send(new CreateChatCommand(request.Name));
        return Ok(response);
    }

    /// <summary>
    /// Get chat info by id
    /// </summary>
    [HttpGet("{chatId:guid}")]
    [ProducesResponseType<GetChatResponse>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetChatById([FromRoute] Guid chatId)
    {
        var response = await _mediator.Send(new GetChatCommand(chatId));
        return Ok(response);
    }

    /// <summary>
    /// Get chats sorted by creation date
    /// </summary>
    [HttpGet]
    [ProducesResponseType<GetChatsResponse>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetChats()
    {
        var response = await _mediator.Send(new GetChatsCommand());
        return Ok(response);
    }

    /// <summary>
    /// Update chat info
    /// </summary>
    [HttpPut("{chatId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateChat([FromRoute] Guid chatId, [FromBody] UpdateChatRequest request)
    {
        await _mediator.Send(new UpdateChatCommand(chatId, request.Name));
        return Ok();
    }

    /// <summary>
    /// Delete chat
    /// </summary>
    [HttpDelete("{chatId:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteChat([FromRoute] Guid chatId)
    {
        await _mediator.Send(new DeleteChatCommand(chatId));
        return Ok();
    }
}