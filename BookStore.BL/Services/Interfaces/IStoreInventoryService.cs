using BookStore.BL.DTO;
using BookStore.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Services.Interfaces
{
    public interface IStoreInventoryService : IRepository<Shop>
    {
        Task<bool> AddShop(AddShopDTO addShopDTO);
        Task<BookDTO> GetShopInventory(int shopId);
        Task<IEnumerable<ShopDTO>> GetAllShops();
    }
    
}


