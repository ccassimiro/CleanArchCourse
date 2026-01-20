using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesQuery = new GetCategoriesQuery();

            return await _mediator.Send(categoriesQuery);
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categoryQuery = new GetCategoryByIdQuery(id.Value);

            return await _mediator.Send(categoryQuery); ;
        }

        public async Task AddAsync(CategoryDTO categoryDto)
        {
            var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDto);
            await _mediator.Send(categoryCreateCommand);
        }

        public async Task UpdateAsync(CategoryDTO categoryDto)
        {
            var categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryDto);
            await _mediator.Send(categoryUpdateCommand);
        }

        public async Task RemoveAsync(int? id)
        {
            var categoryRemoveCommand = new CategoryRemoveCommand(id.Value);
            await _mediator.Send(categoryRemoveCommand);
        }
    }
}
