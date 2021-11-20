using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.Entity
{
    public class Shop
    {
        //[Key]
        public int ShopId { get; set; }
        [Required]
        [StringLength(150)]
        public string ShopName { get; set; }
        [StringLength(150)]
        public string ShopState { get; set; }
    }
}
