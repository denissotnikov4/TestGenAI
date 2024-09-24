using System.Net;
using System.Threading.Tasks;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.Tokens.CreateToken;
using SampleProject.Application.Tokens.CreateToken.Dto.Requests;
using SampleProject.Application.Tokens.CreateToken.Dto.Responses;

namespace SampleProject.API.Tokens;

[Route("api/v1/tokens")]
[ApiVersion("1.0")]
[ApiController]
public class TokensController : ControllerBase
{
    private readonly IMediator _mediator;

    public TokensController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Create JWT-token
    /// </summary>
    [HttpPost]
    [ProducesResponseType<CreateTokenResponse>((int)HttpStatusCode.OK)]
    [Authorize]
    public async Task<IActionResult> CreateToken([FromBody] CreateTokenRequest request)
    {
        var response = await _mediator.Send(new CreateTokenCommand(request.Username, request.Password));
        return Ok(response);
    }
}