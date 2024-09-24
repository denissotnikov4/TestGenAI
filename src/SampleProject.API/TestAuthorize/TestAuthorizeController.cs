using System.Net;
using System.Threading.Tasks;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.Tokens.CreateToken;
using SampleProject.Application.Tokens.CreateToken.Dto.Requests;
using SampleProject.Application.Tokens.CreateToken.Dto.Responses;

namespace SampleProject.API.TestAuthorize;

[Route("api/v1/test/auth")]
[ApiVersion("1.0")]
[ApiController]
public class TestAuthorizeController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestAuthorizeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Test to check the correctness of the authorization
    /// </summary>
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> TestAuthorize([FromBody] CreateTokenRequest request)
    {
        return Ok();
    }
}