using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo_list.Application.Commands.TodoHeadCommand;
using Todo_list.Application.Queries.TodoHeadQuery;

namespace Todo_list.WebAPI.Modules;

public static class TodoHeadModule
{
    public static void RegisterTodoHeadRoutes(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/todo-heads").WithTags("TodoHeads");

        group.MapPost("", async (ISender sender, CreateTodoHeadCommand command, CancellationToken cancellationToken) =>
        {
            var id = await sender.Send(command, cancellationToken);
            return Results.Created($"/todo-head/{id}", new { Message = "Başarıyla eklendi!" });
        });

        group.MapGet("", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new GetAllTodoHeadsWithItemsQuery(), cancellationToken);
            return Results.Ok(result);
        });

        group.MapGet("/{id}", async (ISender sender, Guid id, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new GetTodoHeadByIdQuery(id), cancellationToken);
            return Results.Ok(result);
        });

        group.MapPut("/{id}", async (ISender sender, Guid id, UpdateTodoHeadCommand command, CancellationToken cancellationToken) =>
        {
            if (id != command.Id)
                return Results.BadRequest(new { Message = "Id uyuşmuyor!" });

            await sender.Send(command, cancellationToken);
            return Results.Ok(new { Message = "Başarıyla güncellendi.", Id = id });
        });

        group.MapDelete("/{id}", async (ISender sender, Guid id, CancellationToken cancellationToken) =>
        {
            await sender.Send(new DeleteTodoHeadCommand(id), cancellationToken);
            return Results.Ok(new { Message = "Başarıyla silindi.", Id = id });
        });
    }

}
