using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.Infrastructure.Repository
{
    public interface ITaskRepository
    {
        void Add(ProjectTask task);

        ProjectTask Remove(int taskId);

        bool Change(ProjectTask task);

        IEnumerable<ProjectTask> GetAllTasks();

        IEnumerable<ProjectTask> FindByManagerId(int managerId);

        IEnumerable<ProjectTask> GetAllEndingTasks();

        ProjectTask FindById(int id);
    }
}
