using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class SilverCustomer : Customer, IDiscount
    {
        public SilverCustomer(string name, string password) : base(name, password)
        {
        }

        public void setDiscount()
        {
           // _totalAmount = 0,9 * TotalAmount;
        }
    }
}
