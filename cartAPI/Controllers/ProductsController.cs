using cartAPI.BasicAuth;
using cartAPI.Data;
using cartAPI.Entities;
using Microsoft.AspNetCore.Mvc;


namespace cartAPI.Controllers
{
    [Authentication]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> repository;
        private readonly IUnitOfWork unitOfWork;
        public ProductsController(IRepository<Product> _repository, IUnitOfWork _unitOfWork)
        {
            repository = _repository;
            unitOfWork = _unitOfWork;
        }
        
        [HttpGet]
        public ActionResult GetProduct()
        {
            var products = repository.GetAll();
            return Ok(products);

        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetProductById(int id)
        {
            var products = repository.GetById(id);
            return Ok(products);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody] Product product)
        {
            repository.Add(product);
            unitOfWork.SaveChanges();
            return Ok(product);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Product product)
        {
            repository.Update(product);
            repository.SaveAll();
            return Ok(product);
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
