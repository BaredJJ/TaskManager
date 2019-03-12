using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста добавьте имя задачи")]
        public string Name { get;set; }

        public DateTime StartDateTime { get; set; }

        
        [NextDate(ErrorMessage = "Пожалуйста введите корректную дату окончания задачи")]
        public DateTime EnDateTime { get; set; }

        public string State { get;set; }

        public int ManagerId { get; set; }
    }
}
