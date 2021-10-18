using AutoMapper;
using cartAPI.Data;
using cartAPI.Dtos;
using cartAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


namespace cartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IRepository<Cart> repository;
        private readonly IMapper mapper;
        private readonly ILogger<CartsController> logger;
        public CartsController(IRepository<Cart> _repository, IMapper _mapper, ILogger<CartsController> _logger)
        {
            repository = _repository;
            mapper = _mapper;
            logger = _logger;
        }

        [HttpGet]
        public ActionResult GetCart()
        {
            var cartItem = repository.GetAll();
            var cartItemResult = mapper.Map<List<CartForAddingDto>>(cartItem);
            logger.LogInformation("The main page has been accessed");
            logger.LogError("bu işlem hatalı");
            return Ok(cartItemResult);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody] Cart cart)
        {
            repository.Add(cart);
            repository.SaveAll();
            return Ok(cart);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            repository.SaveAll();
            return Ok();
        }
    }
}
