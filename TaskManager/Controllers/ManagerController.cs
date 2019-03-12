using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Controllers
{
    [Authorize]
    public class ManagerController:Controller
    {
        private readonly IDataService _dataService;

        public ManagerController(IDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public ViewResult Index() => View(_dataService.ManagerRepository.GetAllManagers());
    }
}
