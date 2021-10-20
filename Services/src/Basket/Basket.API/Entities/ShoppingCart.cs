using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }
        
        public ShoppingCart(string UserName)
        {

        }
        public string UserName { get; set; }
        public List<ShoppingCart> List { get; set; }
    }
}
