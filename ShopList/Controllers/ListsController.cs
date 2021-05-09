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
    [Route("[Controller]")]
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

        // Get /Lists
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var results = _repository.GetAll();
            return View(await results);
        }

        [HttpGet("{id:int}")]
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

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ListViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newList = _mapper.Map<List>(model);

                    await _repository.Add(newList);
                    await _repository.SaveAsync();

                    return Created($"/Lists/Details/{newList.Id}", _mapper.Map<ListViewModel>(newList));

                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new list: {ex}");
            }

            return BadRequest("Failed to save new order.");

        }
    }
}
