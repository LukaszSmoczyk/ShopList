using Microsoft.AspNetCore.Mvc;
using ShopList.Data;

namespace ShopList.Controllers
{

    public class AppController : Controller
    {
        private readonly IListRepository _repository;

        public AppController(IListRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult AllLists()
        {
            return RedirectToAction("Index", "Lists");
        }
    }
}
