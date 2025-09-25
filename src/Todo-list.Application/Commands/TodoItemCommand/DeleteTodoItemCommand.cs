using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo_list.Application.Interfaces;

namespace Todo_list.Application.Commands.TodoItemCommand;

public sealed record DeleteTodoItemCommand(Guid Id) : IRequest;
public sealed class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly ITodoItemRepository _itemRepository;
    public DeleteTodoItemHandler(ITodoItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        await _itemRepository.DeleteAsync(request.Id);
    }
}
