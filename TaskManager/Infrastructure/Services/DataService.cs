using System;
using TaskManager.Infrastructure.Repository;

namespace TaskManager.Infrastructure.Services
{
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _dbContext;

        public DataService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            ManagerRepository = new EfManagerRepository(_dbContext);
            TaskRepository = new EfTaskRepository(_dbContext);
        }

        public IManagerRepository ManagerRepository { get; }

        public ITaskRepository TaskRepository { get; }

        public void SaveChanges() => _dbContext.SaveChanges();
    }
}
