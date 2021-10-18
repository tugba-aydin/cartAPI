using cartAPI.Entities;
using cartAPI.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace cartAPI.Features.Products.Commands
{
    public class CreateProductCommand:IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
        {
            private readonly IProductsService productsService;
            public CreateProductCommandHandler(IProductsService _productsService)
            {
                productsService = _productsService;
            }
            public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    Id = request.Id,
                    Name = request.Name,
                    Photo = request.Photo,
                    Stock=request.Stock,
                    Price=request.Price
                };

                return await productsService.CreateProduct(product);
            }
        }
    }
}
