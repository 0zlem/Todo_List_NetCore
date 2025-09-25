using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo_list.Application.Dtos
{
    public class TodoHeadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;

        public List<TodoItemDto> Items { get; set; } = new List<TodoItemDto>();
    }
}