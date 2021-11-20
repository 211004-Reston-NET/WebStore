using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.DTO
{
    public class AddShopDTO
    {
        [Required]
        [StringLength(150)]
        public string ShopName { get; set; }
        [StringLength(150)]
        public string ShopState { get; set; }
    }
}
