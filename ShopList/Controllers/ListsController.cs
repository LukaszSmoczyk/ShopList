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
    [Route("api/[Controller]")]
    public class ListsController : Controller
    {
        public readonly IShopListRepository _repository;
        public readonly ILogger<ListsController> _logger;
        public readonly IMapper _mapper;
        private readonly Random _random;

        public ListsController(IShopListRepository repository, ILogger<ListsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AllLists()
        {
            var results = _repository.GetAllLists();
            return View(results);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var list = _repository.GetListById(id);
                if (list != null) return Ok(_mapper.Map<ListViewModel>(list));
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to return list: {ex}");
                return BadRequest($"Failed to return list");
            }
        }


        [HttpGet("add")]
        public IActionResult CreateList()
        {
            return View();
        }
    }
}
