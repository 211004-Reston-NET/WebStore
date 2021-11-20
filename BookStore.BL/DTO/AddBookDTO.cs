using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.DTO
{
    public class AddBookDTO
    {
        [Required]
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ShopId { get; set; }
    }
}
