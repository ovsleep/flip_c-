using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    public class OrderDetailsDT
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int StockItemId { get; set; }
    }
}
