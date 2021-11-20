using BookStore.DL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int OrderQuantity { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal OrderTotal { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
