

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

        private double _price;
        public double Price
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

        private double _totalSumPerProduct;
        public double TotalSumPerProduct
        {
            get { return _totalSumPerProduct; }
            set { _totalSumPerProduct = value; }
        }

        public Product(string objectname, int price)
        {
            _price = price;
            _objectName = objectname;
            TotalSumPerProduct = 0;
        }
        public override string ToString()
        {
            return $"{_objectName}, {_price} SEK/st. {_quantity} st. {TotalSumPerProduct} SEK.";
        }

    }
}
