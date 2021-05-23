using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopList.Data;
using ShopList.Data.Entities;
using ShopList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Controllers
{
    [Route("api/[controller]")]
    public class ListsController : Controller
    {
        public readonly IListRepository _listRepository;
        public readonly IItemRepository _itemRepository;
        public readonly ILogger<ListsController> _logger;
        public readonly IMapper _mapper;
        private readonly Random _random;

        public ListsController(IListRepository listRepository, IItemRepository itemRepository, ILogger<ListsController> logger, IMapper mapper)
        {
            _listRepository = listRepository;
            _itemRepository = itemRepository;
            _logger = logger;
            _mapper = mapper;
        }

        // Get /api/Lists

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var results = _listRepository.GetAll();
            return View(await results);
        }

/*        [HttpGet("Details/{id:int}")]
        public ActionResult Details(int id)
        {
            if (_listRepository.GetListById(id) != null)
            {
                return RedirectToAction("Index", "ItemsController", {@id);
            }
            else
            {
                return NotFound();
            }
        }*/

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ListViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newList = _mapper.Map<List>(model);
                newList.Items.Count.Equals(0);

                await _listRepository.Add(newList);
                await _listRepository.SaveAsync();
                return RedirectToAction("Index", "Lists");

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
