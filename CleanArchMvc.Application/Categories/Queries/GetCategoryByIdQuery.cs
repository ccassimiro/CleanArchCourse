using CleanArchMvc.Application.DTOs;
using MediatR;

namespace CleanArchMvc.Application.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryDTO>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
