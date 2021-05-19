using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopList.Data;
using ShopList.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopList.Controllers
{
    [Route("api/Lists")]
    public class ItemsController : Controller
    {
        public readonly IShopListRepository _repository;
        public readonly ILogger<ItemsController> _logger;
        public readonly IMapper _mapper;
        private readonly Random _random;

        public ItemsController(IShopListRepository repository, ILogger<ItemsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        /*        [HttpGet("/Details/{id:int}")]
                public async Task<IActionResult> Index(int id)
                {
                    try
                    {
                        var items = _repository.GetAllItemsInList(id);
                        if (items != null)
                        {
                            return View(await items);
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
                }*/

        public PartialViewResult ItemsDetails(int id)
        {
            var items = _repository.GetAllItemsInList(id);
            if (items != null)
            {
                return PartialView(items);
            }
            else
            {
                return PartialView("/error");
            }
        }
    }
}
