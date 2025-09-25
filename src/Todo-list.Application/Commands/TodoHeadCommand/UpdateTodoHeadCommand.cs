using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Todo_list.Application.Interfaces;

namespace Todo_list.Application.Commands.TodoHeadCommand;

public sealed record UpdateTodoHeadCommand(Guid Id, string newTitle) : IRequest<Unit>;

public sealed class UpdateTodoHeadCommandValidator : AbstractValidator<UpdateTodoHeadCommand>
{
    public UpdateTodoHeadCommandValidator()
    {
        RuleFor(i => i.newTitle).MinimumLength(3).NotEmpty().WithMessage("Başlık boş olamaz ve en az üç karakter içermelidir!");
    }
}

public sealed class UpdateTodoHeadHandler : IRequestHandler<UpdateTodoHeadCommand, Unit>
{
    private readonly ITodoHeadRepository _headRepository;
    public UpdateTodoHeadHandler(ITodoHeadRepository headRepository)
    {
        _headRepository = headRepository;
    }
    public async Task<Unit> Handle(UpdateTodoHeadCommand request, CancellationToken cancellationToken)
    {
        var head = await _headRepository.GetByIdAsync(request.Id);


        if (head is null)
        {
            throw new Exception("Başlık bulunamadı.");
        }

        head.Title = request.newTitle;
        await _headRepository.UpdateAsync(head);
        return Unit.Value;
    }
}
