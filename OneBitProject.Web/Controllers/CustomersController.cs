namespace OneBitProject.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using OneBitProject.Application.Customer.Commands.Create;
    using OneBitProject.Application.Customer.Queries.GetAll;

    public class CustomersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GetAllCustomersViewModel>> GetAll()
        {
            var result = await this.Mediator.Send(new GetAllCustomersQuery());
            return this.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCustomerCommand command)
        {
            await this.Mediator.Send(command);

            return this.NoContent();
        }
    }
}
