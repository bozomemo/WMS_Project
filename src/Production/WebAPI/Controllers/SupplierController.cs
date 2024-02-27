using Application.Features.SupplierF.Commands.CreateSupplier;
using Application.Features.SupplierF.Commands.DeleteSupplier;
using Application.Features.SupplierF.Commands.UpdateSupplier;
using Application.Features.SupplierF.Queries.GetAllActiveSuppliers;
using Application.Features.SupplierF.Queries.GetAllSuppliers;
using Application.Features.SupplierF.Queries.GetSupplierById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SupplierController : BaseController
    {
        [HttpGet("GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {
            var query = new GetAllActiveSuppliersQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSuppliersQuery();

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetSupplierByIdQuery { Id = id };

            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteSupplierCommand { Id = id };

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
