using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Infrastructure.Repository
{
    public class EfTaskRepository:ITaskRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EfTaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(ProjectTask task)
        {
            if(task == null) return;

            _dbContext.Task.Add(task);
        }

        public ProjectTask Remove(int taskId)
        {
            var task = FindById(taskId);

            if (task == null) return null;

            _dbContext.Task.Remove(task);
            return task;
        }

        public bool Change(ProjectTask task)
        {
            var source = FindById(task.Id);
            if (source == null) return false;

            source.Name = task.Name;
            source.StartDateTime = task.StartDateTime;
            source.EnDateTime = task.EnDateTime;
            source.State = task.State;
            source.ManagerId = task.ManagerId;

            return true;
        }

        public IEnumerable<ProjectTask> GetAllTasks() => _dbContext.Task;


        public IEnumerable<ProjectTask> FindByManagerId(int managerId) => 
            _dbContext.Task.Where(x => x.ManagerId == managerId);


        public IEnumerable<ProjectTask> GetAllEndingTasks() => _dbContext.Task
            .Where(x => x.EnDateTime.Subtract(DateTime.Now) < TimeSpan.FromDays(2));


        public ProjectTask FindById(int id) => _dbContext.Task.FirstOrDefault(x => x.Id == id);

    }
}
