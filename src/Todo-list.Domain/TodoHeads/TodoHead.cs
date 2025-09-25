using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_list.Domain.Abstractions;
using Todo_list.Domain.TodoItems;

namespace Todo_list.Domain.TodoHeads;

public class TodoHead : Entity
{
    public string Title { get; set; } = default!;

    public ICollection<TodoItem> Items { get; set; } = new List<TodoItem>();

}
