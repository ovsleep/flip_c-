using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class OrderDT
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public int CustomerId { get;  set; }
    }
}
