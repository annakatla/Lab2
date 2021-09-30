using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class BronzeCustomer : Customer
    {

        private double _discount;
        public double Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }

        public BronzeCustomer(string name, string password) : base(name, password)
        {
            _discount = 0.95;
        }

        public override void AddToCart(Product product, int quantity)
        {
            double productCost = _discount * product.Price * quantity;
            Shoppingcart.Add(product);
            product.Quantity += quantity;
            product.TotalSumPerProduct = product.TotalSumPerProduct + productCost;
            MyPrice += productCost;
        }
        public override void RemoveFromCart(Product product, int quantity)
        {
            if (quantity > product.Quantity)
            {
                quantity = product.Quantity;
            }
            double productCost = _discount * product.Price * quantity;
            product.Quantity -= quantity;
            product.TotalSumPerProduct = product.TotalSumPerProduct - productCost;
            if (product.Quantity <= 0)
            {
                Shoppingcart.Remove(product);
            }
            MyPrice -= productCost;
        }
    }
}
