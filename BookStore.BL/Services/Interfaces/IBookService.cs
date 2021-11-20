using BookStore.BL.DTO;
using BookStore.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Services.Interfaces
{
    public interface IBookService:IRepository<Book>
    {
        Task<IEnumerable<BookDTO>> GetAllBooks();
        Task<BookDTO> GetBookBy(string BookTitle);
        Task<BookDTO> GetBookBy(int Id);
        Task<bool> AddBook(AddBookDTO addBookDTO);
        Task<bool> UpdateBook(BookDTO bookDTO);
        Task<IEnumerable<BookDTO>> FindBookByName(string name);
    }
}
