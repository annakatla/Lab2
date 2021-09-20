using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class BronzeCustomer : Customer, IDiscount
    {
        public BronzeCustomer(string name, string password) : base(name, password)
        {
        }
        public void setDiscount()
        {
            //TotalAmount = 0,95 * TotalAmount;
        }
    }
}
