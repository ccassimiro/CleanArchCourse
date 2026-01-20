using CleanArchMvc.Application.DTOs;
using MediatR;

namespace CleanArchMvc.Application.Categories.Commands
{
    public abstract class CategoryCommand : IRequest<CategoryDTO>
    {
        public string Name { get; set; }
    }
}
