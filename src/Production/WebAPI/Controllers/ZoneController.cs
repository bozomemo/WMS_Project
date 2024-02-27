using Application.Features.Zone.Commands.CreateZone;
using Application.Features.Zone.Commands.DeleteZone;
using Application.Features.Zone.Commands.UpdateZone;
using Application.Features.Zone.Queries.GetAllActiveZones;
using Application.Features.Zone.Queries.GetAllZones;
using Application.Features.Zone.Queries.GetZoneById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ZoneController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateZoneCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateZoneCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteZoneCommand { Id = id };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {
            var query = new GetAllActiveZonesQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllZonesQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetZoneByIdQuery { Id = id };

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
