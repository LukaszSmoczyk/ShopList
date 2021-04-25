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
        public ListsController(IShopListRepository repository, ILogger<ListsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var results = _repository.GetAllLists();
            return View(results);
        }

/*        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<List>> Get()
        {
            try
            {
                return Ok(_repository.GetAllLists());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get lists: {ex}");
                return BadRequest("Failed to get lists");
            }
        }*/


        [HttpPost]
        public IActionResult CreateList([FromBody] ListViewModel model)
        {
            //add it to the db
            try
            {
                if (ModelState.IsValid)
                {
                    var newList = _mapper.Map<ListViewModel, List>(model);

                    if (newList.CreationDate == DateTime.MinValue)
                    {
                        newList.CreationDate = DateTime.Now;
                    }

                    _repository.AddEntity(newList);
                    if (_repository.SaveAll())
                    {
                        return Created($"/App/Lists/{newList.Id}", _mapper.Map<List, ListViewModel>(newList));
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save a new list: {ex}");
            }

            return BadRequest("Failed to save new list");
        }
    }
}
