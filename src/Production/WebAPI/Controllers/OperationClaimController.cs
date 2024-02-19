using Application.Features.OperationClaim.Commands.DeleteOperationClaim;
using Application.Features.OperationClaim.Commands.UpdateOperationClaim;
using Application.Features.OperationClaim.Queries.GetAllActiveOperationClaims;
using Application.Features.OperationClaim.Queries.ReadAllOperationClaims;
using Application.Features.OperationClaim.Queries.ReadOperationClaimById;
using Application.Features.OperationClaimFeature.Commands.CreateOperationClaim;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OperationClaimController : BaseController
    {
        [HttpGet("GetAllOperationClaims")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllOperationClaimQuery();

            var operationClaims = await Mediator.Send(query);

            return Ok(operationClaims);
        }

        [HttpGet("GetAllActiveOperationClaims")]
        public async Task<IActionResult> GetActive()
        {
            var query = new GetAllActiveOperationClaimsQuery();

            var operationClaims = await Mediator.Send(query);

            return Ok(operationClaims);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var query = new GetOperationClaimByIdQuery { Id = Id };

            var operationClaim = await Mediator.Send(query);

            return Ok(operationClaim);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand command)
        {
            var updatedOperationClaim = await Mediator.Send(command);

            return Created("", updatedOperationClaim);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var command = new DeleteOperationClaimCommand { Id = Id };

            var deletedOperationClaimCommand = await Mediator.Send(command);

            return Ok(deletedOperationClaimCommand);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand command)
        {
            var updatedOperaionClaimCommand = await Mediator.Send(command);

            return Ok(updatedOperaionClaimCommand);
        }

    }
}