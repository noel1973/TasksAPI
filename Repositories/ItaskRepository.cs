using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksAPI.Models;

namespace TasksAPI.Repositories
{
    public interface ItaskRepository
    {
        Task<IEnumerable<Tasks>> Get();

        Task<Tasks> Get(int id);

        Task<Tasks> Create(Tasks task);

        Task Update(Tasks task);

        Task Delete(int id);


    }
}
