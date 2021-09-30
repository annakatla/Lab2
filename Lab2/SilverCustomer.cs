﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class SilverCustomer : Customer
    {
        private double _discount;
        public double Procent
        {
            get { return _discount; }
            set { _discount = value; }
        }
        public SilverCustomer(string name, string password) : base(name, password)
        {
            _discount = 0.9;
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
            double productCost = _discount * product.Price * quantity;
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
