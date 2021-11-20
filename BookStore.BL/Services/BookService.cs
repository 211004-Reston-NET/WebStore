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
    public class BookService:Repository<Book>,IBookService
    {
        public BookService(StoreContext context)
            :base(context)
        {

        }
        public async Task<bool> AddBook(AddBookDTO addBookDTO)
        {
            Book book = new Book()
            {
                //Properties of Book.cs = addBookDTO.AddBookDTO Properties
                BookAuthor = addBookDTO.BookAuthor,
                BookPrice = addBookDTO.Price,
                BookQuantity = addBookDTO.Quantity,
                ShopId = addBookDTO.ShopId,
                BookTitle = addBookDTO.BookTitle,
            };
            var isCreated=await Save(book);
            if (isCreated > 0)
                return true;
            return false;
        }
        public async Task<BookDTO> GetBookBy(int Id)
        {
            return await _context.Books.Where(f => f.BookId == Id)
                .Include(f=>f.Shope)
                .Select(f=>new BookDTO
                {
                    //Properties from BookDTO = f.Book.cs Properties
                    BookAuthor = f.BookAuthor,
                    BookId=f.BookId,
                    BookTitle=f.BookTitle,
                    Price=f.BookPrice,
                    Quantity=f.BookQuantity,
                    ShopId=f.ShopId,
                    ShopName=f.Shope.ShopName,
                    ShopState=f.Shope.ShopState
                })
                .FirstOrDefaultAsync();

        }
        public async Task<BookDTO> GetBookBy(string BookTitle)
        {
            return await _context.Books.Where(f => f.BookTitle == BookTitle)
                .Include(f => f.Shope)
                .Select(f => new BookDTO
                {
                    //Properties from BookDTO = f.Book.cs Properties
                    BookAuthor = f.BookAuthor,
                    BookId = f.BookId,
                    BookTitle = f.BookTitle,
                    Price = f.BookPrice,
                    Quantity = f.BookQuantity,
                    ShopId = f.ShopId,
                    ShopName = f.Shope.ShopName,          //Shope is an Object of Shop Class inside Book.cs
                    ShopState = f.Shope.ShopState
                })
                .FirstOrDefaultAsync();

        }
        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            return await _context.Books
                .Include(f => f.Shope)
                .Select(f => new BookDTO
                {
                    //Properties from BookDTO = f.Book.cs Properties
                    BookAuthor = f.BookAuthor,
                    BookId = f.BookId,
                    BookTitle = f.BookTitle,
                    Price = f.BookPrice,
                    Quantity = f.BookQuantity,
                    ShopId = f.ShopId,
                    ShopName = f.Shope.ShopName,
                    ShopState = f.Shope.ShopState
                })
                .ToListAsync();

        }
        public async Task<bool> UpdateBook(BookDTO bookDTO)
        {
            if(bookDTO?.BookId>0 && bookDTO?.ShopId > 0)
            {
               var bookExist=await _context.Books.Where(f => f.BookId == bookDTO.BookId).FirstOrDefaultAsync();
                if (bookExist?.BookId > 0)
                {
                    bookExist.BookAuthor = bookDTO.BookAuthor;
                    bookExist.BookPrice = bookDTO.Price;
                    bookExist.BookQuantity = bookDTO.Quantity;
                    bookExist.BookTitle = bookDTO.BookTitle;
                    bookExist.ShopId = bookDTO.ShopId;
                    await Update(bookExist);
                    return true;
                }
            }
            return false;
        }
        public async Task<IEnumerable<BookDTO>> FindBookByName(string name)
        {
            return await _context.Books
                .Include(f=>f.Shope)
                .Where(f => f.BookTitle.Contains(name) 
                || f.BookAuthor.Contains(name))
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
                })
                .ToListAsync();
        }

    }
}
