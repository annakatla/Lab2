using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class SilverCustomer : Customer
    {
        private double _procent;
        public double Procent
        {
            get { return _procent; }
            set { _procent = value; }
        }
        public SilverCustomer(string name, string password) : base(name, password)
        {
            _procent = 0.9;
        }

        public override void AddToCart(Product product, int quantity)
        {
            double productCost = _procent * product.Price * quantity;
            Shoppingcart.Add(product);
            product.Quantity += quantity;
            product.TotalSumPerProduct = product.TotalSumPerProduct + productCost;
            MyPrice += productCost;
        }

        public override void RemoveFromCart(Product product, int quantity)
        {
            double productCost = _procent * product.Price * quantity;
            product.Quantity -= quantity;
            if (product.Quantity <= 0)
            {
                product.Quantity = 0;
                product.TotalSumPerProduct = 0;
            }
            else
            {
                product.TotalSumPerProduct = product.TotalSumPerProduct - productCost;
            }
            MyPrice -= productCost;
        }
    }
}
