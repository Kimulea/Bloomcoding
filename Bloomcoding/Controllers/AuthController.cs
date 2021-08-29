using Domain;
using Features.AuthFeatures.Commands;
using Features.AuthFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloomcoding.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly JwtService _jwtService;

        public AuthController(IMediator mediator, JwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(GetUserByEmailQuery query)
        {
            var user = _mediator.Send(query).Result;

            if (user == null)
            {
                return BadRequest(new { message = "user not exists" });
            }

            if (!BCrypt.Net.BCrypt.Verify(query.Password, user.Password))
            { 
                return BadRequest(new { message = "password is not correct" });
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt);

            return Ok(user);
        }

        [HttpGet("User")]
        public async Task<IActionResult> User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _mediator.Send(new GetUserByIdQuery { Id = userId}).Result;

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "succes"
            });
        }
    }
}
