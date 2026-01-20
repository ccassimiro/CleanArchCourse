using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands
{
    public abstract class ProductCommand : IRequest<Product>
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }
        public int Stock { get; protected set; }
        public string Image { get; set; }
        public int CategoryId { get; protected set; }
    }
}
