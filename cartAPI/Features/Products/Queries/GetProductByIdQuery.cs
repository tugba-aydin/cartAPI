using cartAPI.Entities;
using cartAPI.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace cartAPI.Features.Products.Queries
{
    public class GetProductByIdQuery:IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly IProductsService productsService;
            public GetProductByIdQueryHandler(IProductsService _productsService)
            {
                productsService = _productsService;
            }
            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                return await productsService.GetProductById(request.Id);
            }
        }
    }
}
