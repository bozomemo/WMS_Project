using Application.Features.UserOperationClaim.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaim.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaim.Queries.GetAllActiveUserOperationClaims;
using Application.Features.UserOperationClaim.Queries.GetAllUserOperationClaims;
using Application.Features.UserOperationClaim.Queries.GetUserOperationClaim;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserOperationClaimController : BaseController
    {
        [HttpGet("GetAllUserOperationClaims")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUserOperationClaimsCommand();

            var userOperationClaims = await Mediator.Send(query);

            return Ok(userOperationClaims);
        }

        [HttpGet("GetAllActiveUserOperationClaims")]
        public async Task<IActionResult> GetAllActive()
        {
            var query = new GetAllActiveUserOperationClaimsQuery();

            var userOperationClaims = await Mediator.Send(query);

            return Ok(userOperationClaims);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetUserOperationClaimByIdCommand { Id = id };

            var userOperationClaim = await Mediator.Send(query);

            return Ok(userOperationClaim);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserOperationClaimCommand command)
        {
            var createdUserOperationClaim = await Mediator.Send(command);

            return Ok(createdUserOperationClaim);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteUserOperationClaimCommand { Id = id };

            var deletedUserOperationCommand = await Mediator.Send(command);

            return Ok(deletedUserOperationCommand);
        }

    }
}