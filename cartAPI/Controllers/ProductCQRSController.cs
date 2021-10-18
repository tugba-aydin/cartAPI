using cartAPI.Features.Products.Commands;
using cartAPI.Features.Products.Queries;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace cartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCQRSController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductCQRSController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result= await mediator.Send(new GetProductsQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("detail")]
        public async Task<IActionResult> Details(int id)
        {
            var resulryById=await mediator.Send(new GetProductByIdQuery() { Id = id });
            return Ok(resulryById);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var resultCreate = await mediator.Send(command);
            try
            {
                CreateProductCommandValidator validator = new CreateProductCommandValidator();
                //validator.ValidateAndThrow(command);
                ValidationResult result = validator.Validate(command);

                if(!result.IsValid)
                        return BadRequest(result.Errors);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(resultCreate);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(int id, UpdateProductCommand command)
        {
            var resultUpdate=await mediator.Send(command);
            return Ok(resultUpdate);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            
             var resultDelete= await mediator.Send(new DeleteProductCommand() { Id = id });
            return Ok(resultDelete);
        }
    }
}
