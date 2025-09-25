using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_list.Application.Dtos
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public bool IsCompleted { get; set; }
    }
}