using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_list.Domain.Abstractions;
using Todo_list.Domain.TodoHeads;

namespace Todo_list.Domain.TodoItems
{
    public class TodoItem : Entity
    {
        public string Name { get; set; } = default!;
        public bool IsCompleted { get; set; }

        public Guid TodoHeadId { get; set; }

        public TodoHead TodoHead { get; set; } = default!;
    }
}