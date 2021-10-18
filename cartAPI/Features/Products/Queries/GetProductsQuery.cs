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
    public class GetProductsQuery:IRequest<IEnumerable<Product>>
    {
        public class GetProductQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
        {
            private readonly IProductsService productsService;

            public GetProductQueryHandler(IProductsService _productsService)
            {
                productsService = _productsService;
            }
            public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                return await productsService.GetProductsList();
            }
        }
    }
}
