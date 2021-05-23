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

        [HttpGet("Details/{id:int}")]
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                if (_listRepository.GetListById(id) != null)
                {
                    var itemListViewModel = new ItemListViewModel
                    {
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

        [HttpPost]
        public async Task<IActionResult> Index(ItemListViewModel model)
        {
            try
            {
                var newItem = _mapper.Map<Item>(model);
                await _itemRepository.Add(newItem);
                await _itemRepository.SaveAsync();

                return View();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to return list: {ex}");
                return BadRequest($"Failed to return list");
            }





            /*            if (ModelState.IsValid)
                        {

                            var newItem = _mapper.Map<Item>(model);
                            var currentListId = newItem.List.Id;

                            if (newItem.DateOfAddingItem == DateTime.MinValue)
                            {
                                newItem.DateOfAddingItem = DateTime.Now;
                            }
                            await _itemRepository.Add(newItem);
                            await _itemRepository.SaveAsync();
                            return CreatedAtAction(nameof(Index), new { id = currentListId });
                        }
                        else
                        {
                            return BadRequest(ModelState);
                        }*/
        }


    }
}
