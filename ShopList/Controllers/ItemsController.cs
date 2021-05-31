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
    [Route("api/Lists")]
    public class ItemsController : Controller
    {
        public readonly IItemRepository _itemRepository;
        public readonly IListRepository _listRepository;
        public readonly ILogger<ItemsController> _logger;
        public readonly IMapper _mapper;
        private readonly Random _random;

        public ItemsController(IItemRepository itemRepository, IListRepository listRepository, ILogger<ItemsController> logger, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _listRepository = listRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("Index/{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                if (_listRepository.GetListById(id) != null)
                {
                    var itemListViewModel = new ItemListViewModel
                    {
                        ListId = _listRepository.GetId(id),
                        ListName = _listRepository.GetListName(id),
                        Items = (List<Item>)await _itemRepository.GetAllItemsInList(id)
                    };
                    return View(itemListViewModel);
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

        [HttpGet("Index/{id:int}/Add")]
        public IActionResult Create(int id)
        {
            if (_listRepository.GetListById(id) != null)
            {
                return View();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("Index/{id:int}/Add")]
        public async Task<IActionResult> Create(int id, ItemListViewModel model)
        {
            if (_listRepository.GetListById(id) != null)
            {
                var newItem = _mapper.Map<Item>(model);
                newItem.List = _listRepository.GetListById(id);
                await _itemRepository.Add(newItem);
                newItem.DateOfAddingItem = DateTime.Now;
                _listRepository.GetListById(id).Items.Add(newItem);
                await _itemRepository.SaveAsync();
                return RedirectToAction("Index", "Items", new { @id = id });

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
