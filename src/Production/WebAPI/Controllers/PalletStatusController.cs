using Application.Features.PalletStatus.Commands.CreatePalletStatus;
using Application.Features.PalletStatus.Commands.DeletePalletStatus;
using Application.Features.PalletStatus.Commands.UpdatePalletStatus;
using Application.Features.PalletStatus.Queries.GetAllActivePalletStatus;
using Application.Features.PalletStatus.Queries.GetAllPalletStatus;
using Application.Features.PalletStatus.Queries.GetPalletStatusById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PalletStatusController : BaseController
    {
        [HttpGet("GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {
            var query = new GetAllActivePalletStatusQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPalletStatusQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetPalletStatusByIdQuery { Id = id };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePalletStatusCommand createPalletStatusCommand)
        {
            var result = await Mediator.Send(createPalletStatusCommand);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePalletStatusCommand updatePalletStatusCommand)
        {
            var result = await Mediator.Send(updatePalletStatusCommand);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeletePalletStatusCommand { Id = id };

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
