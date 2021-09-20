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

        public Product(string objectname, int price)
        {
            _price = price;
            _objectName = objectname;
        }

        public override string ToString()
        {
            return $"{_objectName}, {_price} SEK.";
        }
    }
}
