using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo_list.Application.Interfaces;
using Todo_list.Domain.TodoItems;
using Todo_list.Infrastructure.Context;

namespace Todo_list.Infrastructure.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly AppDbContext _context;
        public TodoItemRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item is not null)
            {
                _context.TodoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TodoItem>> GetByHeadIdAsync(Guid headId)
        {
            return await _context.TodoItems.Where(i => i.TodoHeadId == headId).ToListAsync();
        }

        public async Task<TodoItem> GetByIdAsync(Guid id)
        {
            var item = await _context.TodoItems.FirstOrDefaultAsync(i => i.Id == id);

            if (item is null) throw new Exception("Öğe bulunamadı!");
            return item;
        }

        public async Task UpdateAsync(TodoItem todoItem)
        {
            _context.TodoItems.Update(todoItem);
            await _context.SaveChangesAsync();
        }
    }
}