using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Models
{
    public class OrderProduct
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Paid { get; set; }
        public string CustomerName { set; get; }
    }
}
