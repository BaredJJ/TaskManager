using TaskManager.Infrastructure.Repository;

namespace TaskManager.Infrastructure.Services
{
    public interface IDataService
    {
        IManagerRepository ManagerRepository { get; }

        ITaskRepository TaskRepository { get; }

        void SaveChanges();
    }
}
