using Microsoft.AspNetCore.Mvc;

namespace Assignment_Api.Controllers
{
    public class AssignmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
