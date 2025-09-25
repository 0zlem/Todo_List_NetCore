using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Todo_list.Application.Commands.TodoHeadCommand;
using Todo_list.Application.Commands.TodoItemCommand;
using Todo_list.Application.Queries.TodoItemQuery;

namespace Todo_list.WebAPI.Modules;

public static class TodoItemModule
{
    public static void RegisterTodoItemRoutes(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/todo-items").WithTags("TodoItems");

        group.MapPost("", async (ISender sender, CreateTodoItemCommand command, CancellationToken cancellationToken) =>
        {
            await sender.Send(command, cancellationToken);
            return Results.Created($"/todo-items/{command.HeadId}", new { Message = "Başarıyla eklendi!" });
        });

        group.MapGet("/by-head/{headId}", async (ISender sender, Guid headId, CancellationToken cancellationToken) =>
        {
            var items = await sender.Send(new GetTodoItemsByHeadIdQuery(headId), cancellationToken);
            return Results.Ok(items);
        });

        group.MapPut("/{id}", async (ISender sender, Guid id, UpdateTodoItemCommand command, CancellationToken cancellationToken) =>
        {
            if (id != command.Id)
                return Results.BadRequest(new { Message = "Id uyuşmuyor!" });

            await sender.Send(command, cancellationToken);
            return Results.Ok(new { Message = "Başarıyla güncellendi.", Id = id });
        });


        group.MapDelete("/{id}", async (ISender sender, Guid id, CancellationToken cancellationToken) =>
        {
            await sender.Send(new DeleteTodoItemCommand(id), cancellationToken);
            return Results.Ok(new { Message = "Başarıyla silindi.", Id = id });
        });

    }
}