using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo_list.Domain.TodoHeads;
using Todo_list.Domain.TodoItems;

namespace Todo_list.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TodoHead> TodoHeads { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoHead>().HasMany(h => h.Items).WithOne(i => i.TodoHead).HasForeignKey(i => i.TodoHeadId);
        }


    }
}
