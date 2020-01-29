namespace OneBitProject.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using OneBitProject.Application.Common.Models;
    using OneBitProject.Application.Customer.Commands.Create;
    using OneBitProject.Application.Customer.Commands.Delete;
    using OneBitProject.Application.Customer.Commands.Update;
    using OneBitProject.Application.Customer.Queries.GetAll;
    using OneBitProject.Application.Customer.Queries.GetById;

    public class CustomersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GetAllCustomersViewModel>> GetAll()
        {
            try
            {
                var result = await this.Mediator.Send(new GetAllCustomersQuery());
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerLookupModel>> Get(int id)
        {
            try
            {
                var result = await this.Mediator.Send(new GetCustomerByIdQuery {Id = id});
                return this.Ok(result);
            }
            catch (Exception e)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCustomerCommand command)
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
        public async Task<ActionResult> Update(UpdateCustomerCommand command)
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
                await this.Mediator.Send(new DeleteCustomerCommand { Id = id });
                return this.NoContent();
            }
            catch (Exception e)
            {
                return this.BadRequest();
            }
        }
    }
}
