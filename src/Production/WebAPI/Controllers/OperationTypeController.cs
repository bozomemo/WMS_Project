using Application.Features.OperationTypeF.Commands.CreateOperationType;
using Application.Features.OperationTypeF.Commands.DeleteOperationType;
using Application.Features.OperationTypeF.Commands.UpdateOperationType;
using Application.Features.OperationTypeF.Queries.GetAllActiveOperationTypes;
using Application.Features.OperationTypeF.Queries.GetAllOperationTypes;
using Application.Features.OperationTypeF.Queries.GetOperationTypeById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OperationTypeController : BaseController
    {
        [HttpGet("GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {
            var opTypes = await Mediator.Send(new GetAllActiveOperationTypesQuery());

            return Ok(opTypes);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var opTypes = await Mediator.Send(new GetAllOperationTypesQuery());

            return Ok(opTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetOperationTypeByIdQuery { Id = id };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOperationTypeCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var query = new DeleteOperationTypeCommand { Id = id };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationTypeCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
