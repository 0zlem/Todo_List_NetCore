using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo_list.Application.Interfaces;

namespace Todo_list.Application.Commands.TodoHeadCommand;

public sealed record DeleteTodoHeadCommand(Guid Id) : IRequest<Unit>;

public sealed class DeleteTodoHeadHandler : IRequestHandler<DeleteTodoHeadCommand, Unit>
{
    private readonly ITodoHeadRepository _headRepository;

    public DeleteTodoHeadHandler(ITodoHeadRepository headRepository)
    {
        _headRepository = headRepository;
    }

    public async Task<Unit> Handle(DeleteTodoHeadCommand request, CancellationToken cancellationToken)
    {
        await _headRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
