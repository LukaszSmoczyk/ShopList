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

        // Get /api/Lists

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var results = _repository.GetAll();
            return View(await results);
        }

        [HttpGet("Details/{id:int}")]
        public IActionResult Details(int id)
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

                await _repository.Add(newList);
                await _repository.SaveAsync();
                return RedirectToAction("Lists", "Details");

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
