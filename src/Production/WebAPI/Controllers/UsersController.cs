using Application.Features.Users.Commands.CreateUserCommand;
using Application.Features.Users.Commands.DeleteUserCommand;
using Application.Features.Users.Commands.UpdateUserCommand;
using Application.Features.Users.Queries.GetAllActiveUsers;
using Application.Features.Users.Queries.GetAllUsersQuery;
using Application.Features.Users.Queries.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
        {
            var userDto = await Mediator.Send(createUserCommand);

            return Created("", userDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteUserCommand { Id = id };

            var deletedUserDto = await Mediator.Send(command);

            return Ok(deletedUserDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand)
        {
            var updatedUserDto = await Mediator.Send(updateUserCommand);

            return Ok(updatedUserDto);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var users = await Mediator.Send(new GetAllUsersQuery());

            return Ok(users);
        }

        [HttpGet("GetAllActiveUsers")]
        public async Task<IActionResult> GetAllActive()
        {
            var users = await Mediator.Send(new GetAllActiveUsersQuery());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var query = new GetUserByIdQuery { Id =  id };

            var userDto = await Mediator.Send(query);

            return Ok(userDto);
        }

    }
}