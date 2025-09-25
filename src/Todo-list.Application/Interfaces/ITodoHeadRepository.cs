using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo_list.Domain.TodoHeads;

namespace Todo_list.Application.Interfaces;

public interface ITodoHeadRepository
{
    Task<TodoHead> GetByIdAsync(Guid id);
    Task<List<TodoHead>> GetAllAsync();
    Task AddAsync(TodoHead todoHead);
    Task UpdateAsync(TodoHead todoHead);
    Task DeleteAsync(Guid id);
    Task<List<TodoHead>> GetAllWithItemAsync();
}
