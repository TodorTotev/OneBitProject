namespace OneBitProject.Application.Order.Commands.Delete
{
    using MediatR;

    public class DeleteOrderCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
