using cartAPI.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace cartAPI.Features.Products.Commands
{
    public class UpdateProductCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IProductsService productsService;
            public UpdateProductCommandHandler(IProductsService _productsService)
            {
                productsService = _productsService;
            }
            public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await productsService.GetProductById(request.Id);

                product.Name = request.Name;
                product.Photo = request.Photo;
                product.Stock = request.Stock;
                product.Price = request.Price;

                return await productsService.UpdateProduct(product);
            }
        }
    }
}
