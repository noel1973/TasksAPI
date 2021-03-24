using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasksAPI.Models
{
    public class TaskContext: DbContext 
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            :base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
