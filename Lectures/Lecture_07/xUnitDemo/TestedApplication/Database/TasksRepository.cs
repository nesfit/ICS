using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestedApplication.Database
{

    public class TasksRepository
    {
        private readonly Func<TasksDbContext> _taskDbContextFactory;

        public TasksRepository(Func<TasksDbContext> taskDbContextFactory)
        {
            this._taskDbContextFactory = taskDbContextFactory;
        }
        public async Task AddTaskAsync(string name)
        {
            await using (var db = _taskDbContextFactory())
            {
                var toAdd = new UserTask()
                {
                    Name = name
                };

                await db.UserTasks.AddAsync(toAdd);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserTask>> GetTasksAsync()
        {
            await using (var db = _taskDbContextFactory())
            {
                return await db.UserTasks.ToListAsync();
            }
        }
    }
}
