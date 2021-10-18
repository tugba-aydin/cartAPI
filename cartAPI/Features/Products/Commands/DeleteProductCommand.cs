using cartAPI.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace cartAPI.Features.Products.Commands
{
    public class DeleteProductCommand:IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
        {
            private readonly IProductsService productsService;

            public DeleteProductCommandHandler(IProductsService _productsService)
            {
                productsService = _productsService;
            }
            public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var product = await productsService.GetProductById(request.Id);
                return await productsService.DeleteProduct(product);
            }
        }
    }
}
