using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo_list.Application.Interfaces;
using Todo_list.Domain.TodoHeads;
using Todo_list.Infrastructure.Context;

namespace Todo_list.Infrastructure.Repositories
{
    public class TodoHeadRepository : ITodoHeadRepository
    {
        private readonly AppDbContext _context;
        public TodoHeadRepository(AppDbContext context) => _context = context;
        public async Task AddAsync(TodoHead todoHead)
        {
            _context.TodoHeads.Add(todoHead);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var head = await _context.TodoHeads.FindAsync(id);
            if (head is not null)
            {
                _context.TodoHeads.Remove(head);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TodoHead>> GetAllAsync()
        {
            return await _context.TodoHeads.ToListAsync();
        }

        public async Task<List<TodoHead>> GetAllWithItemAsync()
        {
            return await _context.TodoHeads.Include(h => h.Items).ToListAsync();
        }

        public async Task<TodoHead> GetByIdAsync(Guid id)
        {
            return await _context.TodoHeads.Include(h => h.Items).FirstOrDefaultAsync(h => h.Id == id) ?? throw new Exception("Başlık bulunamadı!");
        }

        public async Task UpdateAsync(TodoHead todoHead)
        {
            _context.TodoHeads.Update(todoHead);
            await _context.SaveChangesAsync();
        }
    }
}