using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [Authorize]
    public class HomeController:Controller
    {
        public ViewResult Index() => View();
    }
}
