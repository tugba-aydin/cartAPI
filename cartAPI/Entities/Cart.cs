using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cartAPI.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPhoto { get; set; }
        public int ProductStock { get; set; }
        public double ProductPrice { get; set; }
    }
}
