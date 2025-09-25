using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo_list.Application.Dtos;
using Todo_list.Application.Interfaces;

namespace Todo_list.Application.Queries.TodoHeadQuery;

public sealed record GetAllTodoHeadsWithItemsQuery() : IRequest<List<TodoHeadDto>>;
public sealed class GetAllTodoHeadsWithItemsHandler : IRequestHandler<GetAllTodoHeadsWithItemsQuery, List<TodoHeadDto>>
{
    private readonly ITodoHeadRepository _headRepository;

    public GetAllTodoHeadsWithItemsHandler(ITodoHeadRepository headRepository)
    {
        _headRepository = headRepository;
    }
    public async Task<List<TodoHeadDto>> Handle(GetAllTodoHeadsWithItemsQuery request, CancellationToken cancellationToken)
    {
        var heads = await _headRepository.GetAllWithItemAsync();

        return heads.Select(h => new TodoHeadDto
        {
            Id = h.Id,
            Title = h.Title,
            Items = h.Items.Select(i => new TodoItemDto
            {
                Id = i.Id,
                Name = i.Name,
                IsCompleted = i.IsCompleted
            }).ToList()
        }).ToList();
    }
}
