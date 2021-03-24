using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksAPI.Models;

namespace TasksAPI.Repositories
{
    public class TaskRepository : ItaskRepository

    {
        private readonly TaskContext _context;
        public TaskRepository(TaskContext context)
        {
            _context = context;
        }
        public async Task<Tasks> Create(Tasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task Delete(int id)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(taskToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tasks>> Get()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> Get(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task Update(Tasks task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
