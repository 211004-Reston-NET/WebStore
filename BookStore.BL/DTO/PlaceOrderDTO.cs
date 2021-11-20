using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.DTO
{
    public class PlaceOrderDTO
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int BookId { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
    }
}
