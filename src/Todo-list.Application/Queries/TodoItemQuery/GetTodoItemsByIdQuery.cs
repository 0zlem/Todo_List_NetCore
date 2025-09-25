using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo_list.Application.Dtos;
using Todo_list.Application.Interfaces;

namespace Todo_list.Application.Queries.TodoItemQuery;

public sealed record GetTodoItemsByHeadIdQuery(Guid HeadId) : IRequest<List<TodoItemDto>>;

public sealed class GetTodoItemsByHeadIdHandler
    : IRequestHandler<GetTodoItemsByHeadIdQuery, List<TodoItemDto>>
{
    private readonly ITodoItemRepository _itemRepository;

    public GetTodoItemsByHeadIdHandler(ITodoItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<List<TodoItemDto>> Handle(GetTodoItemsByHeadIdQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetByHeadIdAsync(request.HeadId);

        return items.Select(i => new TodoItemDto
        {
            Id = i.Id,
            Name = i.Name,
            IsCompleted = i.IsCompleted
        }).ToList();
    }
}
