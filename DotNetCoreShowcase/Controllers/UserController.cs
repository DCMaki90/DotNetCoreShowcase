using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreShowcase.Models.Showcase;
using DotNetCoreShowcase.Services.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreShowcase.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) => this._mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<string>> GetUserByEmail(string email)
        {
            Users result;
            try
            {
                result = await this._mediator.Send(new GetUserByEmail.Query(email));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }
    }
}
