using Application.Features.Users.Commands.CreateUserCommand;
using Application.Features.Users.Queries.GetAllUsersQuery;
using Application.Features.Users.Queries.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IHttpContextAccessor httpContextAccessor) : BaseController(httpContextAccessor)
    {
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var users = await Mediator!.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int Id)
        {
            var user = await Mediator!.Send(new GetUserByIdQuery { Id = Id });
            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var newUser = await Mediator!.Send(createUserCommand);
            return Ok(newUser);
        }
    }
}
