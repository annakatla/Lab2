using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    interface IShoppingCart
    {
        abstract void addToCart(Product product, int quantity);

        abstract void showCart(Customer customer);

        abstract void removeFromCart(Product product);


    }
}
