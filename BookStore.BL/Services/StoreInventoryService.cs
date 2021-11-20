using BookStore.BL.DTO;
using BookStore.BL.Services.Interfaces;
using BookStore.DL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Services
{
    public class StoreInventoryService : Repository<Shop>, IStoreInventoryService
    {
        public StoreInventoryService(StoreContext context)
           : base(context)
        {

        }
        public async Task<bool> AddShop(AddShopDTO addShopDTO)
        {
            Shop shop = new Shop()
            {
                ShopName = addShopDTO.ShopName,
                ShopState = addShopDTO.ShopState,
            };
           var isCreated= await Save(shop);
            if (isCreated > 0)
                return true;
            return false;
        }

        public async Task<BookDTO> GetShopInventory(int shopId)
        {
            return await _context.Books.Where(f => f.ShopId == shopId)
                .Include(f => f.Shope)
                .Select(f => new BookDTO
                {

                    BookAuthor = f.BookAuthor,
                    BookId = f.BookId,
                    BookTitle = f.BookTitle,
                    Price = f.BookPrice,
                    Quantity = f.BookQuantity,
                    ShopId = f.ShopId,
                    ShopName = f.Shope.ShopName,
                    ShopState = f.Shope.ShopState
                }).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<ShopDTO>> GetAllShops()
        {
           return await  _context.Shops
                .Select(f => new ShopDTO
                {
                    ShopId = f.ShopId,
                    ShopName = f.ShopName,
                    ShopState = f.ShopState
                }).ToListAsync();
        }
    }
}
