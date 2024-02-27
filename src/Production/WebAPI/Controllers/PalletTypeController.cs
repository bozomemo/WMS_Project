using Application.Features.PalletTypeF.Commands.CreatePalletType;
using Application.Features.PalletTypeF.Commands.DeletePalletType;
using Application.Features.PalletTypeF.Commands.UpdatePalletType;
using Application.Features.PalletTypeF.Queries.GetAllActivePalletTypes;
using Application.Features.PalletTypeF.Queries.GetAllPalletTypes;
using Application.Features.PalletTypeF.Queries.GetPalletTypeById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PalletTypeController : BaseController
    {
        [HttpGet("GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {
            var query = new GetAllActivePalletTypesQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPalletTypesQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetPalletTypeByIdQuery { Id = id };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePalletTypeCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePalletTypeCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeletePalletTypeCommand { Id = id };

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
