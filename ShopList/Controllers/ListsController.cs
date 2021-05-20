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

        [HttpGet("Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var list = _listRepository.GetListById(id);

                if (list != null)
                {
                   
                    return View(await list);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to return list: {ex}");
                return BadRequest($"Failed to return list");
            }
        }

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
                return RedirectToAction("Lists", "Details");

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("List/{id:int}")]
        public async Task<IActionResult> List(int id, List model)
        {
            var newListName = _mapper.Map<List>(model);

            var itemListViewModel = new ItemListViewModel
            {
                ListName = newListName.ListName,
                Items = (List<Item>)await _itemRepository.GetAllItemsInList(id)
            };

            return View(itemListViewModel);
        }
    }
}
