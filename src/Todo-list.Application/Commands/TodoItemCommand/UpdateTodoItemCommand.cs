using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Todo_list.Application.Interfaces;

namespace Todo_list.Application.Commands.TodoItemCommand;

public sealed record UpdateTodoItemCommand(Guid Id, string newName, bool IsCompleted) : IRequest;
public sealed class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoItemCommandValidator()
    {
        RuleFor(i => i.newName).MinimumLength(2).NotEmpty().WithMessage("En az üç karakter içermelidir!");
    }
}

public sealed class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly ITodoItemRepository _itemRepository;

    public UpdateTodoItemHandler(ITodoItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(request.Id);
        if (item is null)
        {
            throw new Exception("Öğe bulunamadı!");
        }

        item.Name = request.newName;
        item.IsCompleted = request.IsCompleted;

        await _itemRepository.UpdateAsync(item);

    }
}
