using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Infrastructure.Services;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize]
    public class TaskController:Controller
    {
        private static string[] statusCode = new[] {"Открыта", "Ожидает подтверждения", "В работе", "Приостановлена"};
        private readonly IDataService _dataService;

        public TaskController(IDataService dataService) =>
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));

        public ViewResult Index()
        {
            return GetIndexView();
        }

        public ViewResult EditState(int taskId)
        {
            var task = _dataService.TaskRepository.FindById(taskId);
            if (task == null)
            {
                return Error("Изменить");
            }

            var manager = _dataService.ManagerRepository.FindById(task.ManagerId);
            if (manager == null)
            {
                return Error("Изменить");
            }

            ViewBag.States = statusCode; 
            ViewBag.Manager = manager;
            return View(task);
        }

        public ViewResult BurningTasks()
        {

            var burningTasks = _dataService.TaskRepository.GetAllEndingTasks();

            ViewBag.Title = "Горящие задачи";
            return View("Index", GetMatching(burningTasks));
        }


        public ViewResult Create() => GetCreateView();


        [HttpPost]
        public ViewResult Create(ProjectTask task)
        {
            task.StartDateTime = DateTime.Now;
            if (!ModelState.IsValid) return GetCreateView();

            _dataService.TaskRepository.Add(task);
            _dataService.SaveChanges();
            TempData["Message"] = task.Name + " задача была добавлена";
            return GetIndexView();
        }
      
        [HttpPost]
        public ViewResult CloseTask(int taskId)
        {
            var task = _dataService.TaskRepository.Remove(taskId);
            if (task != null)
            {
                _dataService.SaveChanges();
                TempData["Message"] = task.Name + " задача была закрыта";
            }
            else Error("Закрыть");
            return GetIndexView();
        }

        [HttpPost]
        public ViewResult EditState(ProjectTask task)
        {
            if (_dataService.TaskRepository.Change(task))
            {
                _dataService.SaveChanges();
                TempData["Message"] = "Статус задачи " + task.Name + " был изменен";
            }
            else
                TempData["Message"] = "Изменить статус задачи " + task.Name + " не получилось";
            return GetIndexView();
        }

        private Dictionary<ProjectTask, Manager> GetMatching(IEnumerable<ProjectTask> tasks)
        {
            var managers = _dataService.ManagerRepository.GetAllManagers().ToDictionary(x => x.Id);
            var dictionary = new Dictionary<ProjectTask, Manager>();
            foreach (var burningTask in tasks)
            {
                dictionary.Add(burningTask, managers[burningTask.ManagerId]);
            }

            return dictionary;
        }

        private ViewResult GetIndexView()
        {
            ViewBag.Title = "Все задачи";
            var tasks = _dataService.TaskRepository.GetAllTasks();
            return View("Index",GetMatching(tasks));
        }

        private ViewResult GetCreateView()
        {
            ViewBag.States = statusCode;
            ViewBag.Managers = _dataService.ManagerRepository.GetAllManagers();
            return View("Create");
        }

        private ViewResult Error(string prefix)
        {
            TempData["Message"] = prefix + " задачу не получилось!";
            return GetIndexView();
        }
    }
}
