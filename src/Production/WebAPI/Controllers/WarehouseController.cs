using Application.Features.WarehouseF.Commands.CreateWarehouse;
using Application.Features.WarehouseF.Commands.DeleteWarehouse;
using Application.Features.WarehouseF.Commands.UpdateWarehouse;
using Application.Features.WarehouseF.Queries.GetAllActiveWarehouses;
using Application.Features.WarehouseF.Queries.GetAllWarehouses;
using Application.Features.WarehouseF.Queries.GetWarehouseById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class WarehouseController : BaseController
    {
        [HttpGet("GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {
            var query = new GetAllActiveWarehousesQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllWarehousesQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetWarehouseByIdQuery { Id = id };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteWarehouseCommand { Id = id };

            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWarehouseCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateWarehouseCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
