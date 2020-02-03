namespace PA.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Application.Order.Commands.Create;
    using Application.Order.Commands.Delete;
    using Application.Order.Commands.Update;
    using Application.Order.Queries.GetById;
    using Application.Order.Queries.GetOrder;

    public class OrdersController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAllOrdersViewModel>> Get(int id)
        {
            try
            {
                var result = await this.Mediator.Send(new GetOrderByIdQuery { Id = id });
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAllOrdersViewModel>> GetAll(int id)
        {
            try
            {
                var result = await this.Mediator.Send(new GetOrderByCustomerIdQuery {Id = id});
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrderCommand command)
        {
            try
            {
                await this.Mediator.Send(command);
                return this.NoContent();
            }
            catch (Exception e)
            {
                return this.BadRequest();
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateOrderCommand command)
        {
            try
            {
                await this.Mediator.Send(command);
                return this.NoContent();
            }
            catch (Exception e)
            {
                return this.BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await this.Mediator.Send(new DeleteOrderCommand {Id = id});
                return this.NoContent();
            }
            catch (Exception e)
            {
                return this.BadRequest();
            }
        }
    }
}