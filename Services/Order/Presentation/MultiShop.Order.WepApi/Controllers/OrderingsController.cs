using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var vv=await _mediator.Send(new GetOrderingQuery());
            return Ok(vv);
        }
        [HttpGet("GetOrderingById")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var vv=await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(vv);
        }
        [HttpPost]
        public async Task<IActionResult > CreateOrderingCommand(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("başarı ile eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderinCommand(id));
            return Ok("başarı ile silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("başarı ile güncellendi");
        }
    }
}
