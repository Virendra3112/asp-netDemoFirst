using System.Collections.Generic;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }
        public List<ShoppingCartItem> ShoppingCartItemList { get; set; }

        //public decimal TotalPrice
        //{
        //    get
        //    {
        //        decimal totalPrice = 0;
        //        foreach (var item in ShoppingCartItemList)
        //        {
        //            totalPrice += totalPrice;
        //        }

        //    }
        //}


    }
}
