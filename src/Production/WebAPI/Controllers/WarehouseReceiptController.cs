using Application.Features.WarehouseReceipt.Commands.CreateWarehouseReceipt;
using Application.Features.WarehouseReceipt.Commands.DeleteWarehouseReceipt;
using Application.Features.WarehouseReceipt.Commands.UpdateWarehouseReceipt;
using Application.Features.WarehouseReceipt.Queries.GetAllActiveWarehouseReceipts;
using Application.Features.WarehouseReceipt.Queries.GetAllWarehouseReceipts;
using Application.Features.WarehouseReceipt.Queries.GetWarehouseReceiptById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class WarehouseReceiptController : BaseController
    {
        [HttpGet("GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {
            var query = new GetAllActiveWarehouseReceiptsQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllWarehouseReceiptsQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetWarehouseReceiptByIdQuery { Id = id };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWarehouseReceiptCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateWarehouseReceiptCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Create([FromRoute] int id)
        {
            var command = new DeleteWarehouseReceiptCommand { Id = id };

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
