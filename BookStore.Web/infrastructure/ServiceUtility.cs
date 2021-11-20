using BookStore.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Web.infrastructure
{
    public class ServiceUtility
    {
        private readonly IStoreInventoryService _shopService;
        private readonly IBookService _bookService;
        public ServiceUtility(IStoreInventoryService shopService,IBookService bookService)
        {
            _shopService = shopService;
            _bookService = bookService;
        }
        public async Task<List<SelectListItem>> GetShopSL()
        {
            try
            {
                List<SelectListItem> ShopSelectList = new List<SelectListItem>();
                var shops = await _shopService.GetAllShops();
                if (shops?.Count() > 0)
                {
                    var shopsSelect = shops
                                     .Select(s => new SelectListItem()
                                     {
                                         Text = s.ShopName,
                                         Value = s.ShopId.ToString()
                                     })
                                     .ToList();

                    if (shops?.Count() > 0)
                    {

                        ShopSelectList.AddRange(shopsSelect);
                    }
                }


                return ShopSelectList.OrderBy(f => f.Text).ToList();
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<List<SelectListItem>> GetBookSL()
        {
            try
            {
                List<SelectListItem> BookSelectList = new List<SelectListItem>();
                var books = await _bookService.GetAllBooks();
                if (books?.Count() > 0)
                {
                    var booksSelect = books
                                     .Select(s => new SelectListItem()
                                     {
                                         Text =$"Book Title:{s.BookTitle}-Book Author:{s.BookAuthor}-Unit Cost:{s.Price}" ,
                                         Value = s.BookId.ToString()
                                     })
                                     .ToList();

                    if (books?.Count() > 0)
                    {

                        BookSelectList.AddRange(booksSelect);
                    }
                }


                return BookSelectList.OrderBy(f => f.Text).ToList();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
