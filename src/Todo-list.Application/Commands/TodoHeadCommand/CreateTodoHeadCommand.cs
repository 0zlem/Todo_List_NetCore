using System.Globalization;
using FluentValidation;
using MediatR;
using Todo_list.Application.Interfaces;
using Todo_list.Domain.TodoHeads;

namespace Todo_list.Application.Commands.TodoHeadCommand;

public sealed record CreateTodoHeadCommand(string Title) : IRequest<Guid>;


public sealed class CreateTodoHeadCommandValidator : AbstractValidator<CreateTodoHeadCommand>
{
    public CreateTodoHeadCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık boş olamaz.")
            .MinimumLength(3).WithMessage("Başlık en az üç karakter içermelidir!");
    }
}

public sealed class CreateTodoHeadHandler : IRequestHandler<CreateTodoHeadCommand, Guid>
{
    private readonly ITodoHeadRepository _headRepository;

    public CreateTodoHeadHandler(ITodoHeadRepository headRepository)
    {
        _headRepository = headRepository;
    }

    public async Task<Guid> Handle(CreateTodoHeadCommand request, CancellationToken cancellationToken)
    {
        var head = new TodoHead { Title = request.Title };
        await _headRepository.AddAsync(head);
        return head.Id;
    }
}
