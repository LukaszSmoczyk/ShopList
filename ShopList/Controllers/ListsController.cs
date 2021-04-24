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

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var results = _repository.GetAllProducts();
                return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(results));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
        }

        [HttpGet]
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

        }
    }
}
