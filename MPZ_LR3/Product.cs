using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZ_LR3
{
    public class Product
    {
        public string SKU { get; set; }  
        public decimal Price { get; set; }  

        public Product(string sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }

        public override string ToString()
        {
            return $"Артикул: {SKU}, Ціна: {Price:C}";
        }
    }


}
