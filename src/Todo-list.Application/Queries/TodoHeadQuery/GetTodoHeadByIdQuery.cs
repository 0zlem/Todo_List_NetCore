using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo_list.Application.Dtos;
using Todo_list.Application.Interfaces;

namespace Todo_list.Application.Queries.TodoHeadQuery;

public sealed record GetTodoHeadByIdQuery(Guid Id) : IRequest<TodoHeadDto>;
public sealed class GetTodoHeadByIdHandler : IRequestHandler<GetTodoHeadByIdQuery, TodoHeadDto>
{
    private readonly ITodoHeadRepository _headRepository;
    public GetTodoHeadByIdHandler(ITodoHeadRepository headRepository)
    {
        _headRepository = headRepository;
    }
    public async Task<TodoHeadDto> Handle(GetTodoHeadByIdQuery request, CancellationToken cancellationToken)
    {
        var head = await _headRepository.GetByIdAsync(request.Id);

        return new TodoHeadDto
        {
            Id = head.Id,
            Title = head.Title,
            Items = head.Items.Select(i => new TodoItemDto
            {
                Id = i.Id,
                Name = i.Name,
                IsCompleted = i.IsCompleted
            }).ToList()
        };
    }
}
