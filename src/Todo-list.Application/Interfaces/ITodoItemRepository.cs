using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_list.Domain.TodoItems;

namespace Todo_list.Application.Interfaces;

public interface ITodoItemRepository
{
    Task<TodoItem> GetByIdAsync(Guid id);
    Task<List<TodoItem>> GetByHeadIdAsync(Guid headId);
    Task AddAsync(TodoItem todoItem);
    Task UpdateAsync(TodoItem todoItem);
    Task DeleteAsync(Guid id);
}
