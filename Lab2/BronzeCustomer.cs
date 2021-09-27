using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class BronzeCustomer : Customer
    {
        public BronzeCustomer(string name, string password) : base(name, password)
        {
        }

        public override void AddToCart(Product product, int quantity)
        {
            Shoppingcart.Add(product);
            product.Quantity += quantity;
            MyPrice += 0.95 * product.Price * quantity;
        }
        public override void RemoveFromCart(Product product, int quantity)
        {
            Shoppingcart.Remove(product);
            product.Quantity -= quantity;
            MyPrice -= 0.95 * product.Price * quantity;
        }
    }
}
