using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.DTO
{
    public class CustomerOrderDTO
    {
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string ShopName { get; set; }
        public string ShopState { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal TotalCost { get; set; }
        public decimal UnitCost { get; set; }
    }
}
