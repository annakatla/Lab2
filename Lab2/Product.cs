using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Product
    {
        private string _objectName;
        public string Objectname
        {
            get { return _objectName; }
            set { _objectName = value; }
        }

        private int _price;
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private int _totalSumPerProduct;
        public int TotalSumPerProduct
        {
            get { return _totalSumPerProduct; }
            set { _totalSumPerProduct = value; }
        }


        public Product(string objectname, int price)
        {
            _price = price;
            _objectName = objectname;
            _totalSumPerProduct = 0;
        }
        public override string ToString()
        {
            return $"{_objectName}, {_price} SEK/st. {_quantity} st. {_totalSumPerProduct} SEK.";
        }

    }
}
