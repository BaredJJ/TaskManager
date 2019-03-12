using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Infrastructure.Repository
{
    public class EfManagerRepository:IManagerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EfManagerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Manager manager)
        {
            if(manager == null) return;

            _dbContext.Manger.Add(manager);
        }

        public IEnumerable<Manager> GetAllManagers() => _dbContext.Manger;

        public Manager FindById(int id) => _dbContext.Manger.FirstOrDefault(x => x.Id == id);

    }
}
