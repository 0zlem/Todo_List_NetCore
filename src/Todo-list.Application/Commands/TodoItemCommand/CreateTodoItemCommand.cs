using FluentValidation;
using MediatR;
using Todo_list.Application.Interfaces;
using Todo_list.Domain.TodoItems;

namespace Todo_list.Application.Commands.TodoItemCommand;

public sealed record CreateTodoItemCommand(Guid HeadId, string Name) : IRequest;

public sealed class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(i => i.Name).MinimumLength(3).NotEmpty().WithMessage("En az iki karakter içermelidir!");
    }
}

public sealed class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand>
{
    private readonly ITodoItemRepository _itemRepository;

    public CreateTodoItemHandler(ITodoItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    public async Task Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var item = new TodoItem { TodoHeadId = request.HeadId, Name = request.Name };
        await _itemRepository.AddAsync(item);

    }
}
