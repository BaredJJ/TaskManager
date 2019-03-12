using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.Infrastructure.Repository
{
    public interface IManagerRepository
    {
        void Add(Manager manager);

        IEnumerable<Manager> GetAllManagers();

        Manager FindById(int id);
    }
}
