using Microsoft.AspNetCore.Mvc;
using ShopList.Data;

namespace ShopList.Controllers
{
    public class AppController : Controller
    {
        private readonly IShopListRepository _repository;

        public AppController(IShopListRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Lists()
        {
            return View();
        }
    }
}
