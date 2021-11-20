using BookStore.BL.DTO;
using BookStore.DL.Entity;
using BookStore.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BL.Services
{
    public class OrderHistoryService : Repository<Order>, IOrderHistoryService
    {
        private readonly IBookService _bookService;
        public OrderHistoryService(StoreContext context,IBookService bookService)
            : base(context)
        {
            _bookService = bookService;
        }

        public OrderHistoryService(StoreContext context) : base(context)
        {
        }
        public async Task<IEnumerable<OrderDTO>> FindCustomerOrder(int custId)
        {
            return await _context.Orders.Where(f => f.CustomerId == custId)
                .Include(f => f.Customer)
                .Include(f => f.Book)
                .Select(f => new OrderDTO
                {
                    //Properties from OrderDTO = f.Order.cs Properties
                    OrderId = f.OrderId,
                    OrderQuantity = f.OrderQuantity,
                    OrderPrice = f.OrderPrice,
                    OrderTotal = f.OrderTotal,
                    CustomerId = f.CustomerId,
                    BookId = f.BookId
                })
                .ToListAsync();
        }

        //Place an Order
        // public async Task<bool> GetOrder(int custId)
        public async Task<IEnumerable<OrderDTO>> GetOrder(int custId)
        {
            return await _context.Orders.Where(f => f.CustomerId == custId)
                .Include(f => f.Customer)
                .Include(f => f.Book)
                .Select(f => new OrderDTO
                {
                    //Properties from OrderDTO = f.Order.cs Properties
                    OrderId = f.OrderId,
                    OrderQuantity = f.OrderQuantity,
                    OrderPrice = f.OrderPrice,
                    OrderTotal = f.OrderTotal,
                    CustomerId = f.CustomerId,
                    BookId = f.BookId
                })
                .ToListAsync();
        }
        public async Task<ResponseModel> PlaceOrder(PlaceOrderDTO placeOrderDTO)
        {
            ResponseModel responseModel = new ResponseModel();
            var book=await _bookService.GetBy(f=>f.BookId==placeOrderDTO.BookId);
            if (book == null)
            {
                responseModel.Message = "Book not found";
                responseModel.IsError = true;
                return responseModel;
            }
            if (book.BookQuantity < placeOrderDTO.Quantity)
            {
                responseModel.Message = $"Quantity: {placeOrderDTO.Quantity} requested is more than the stock: {book.BookQuantity}";
                responseModel.IsError = true;
                return responseModel;
            }
            Order order = new Order()
            {
                BookId = placeOrderDTO.BookId,
                CustomerId = placeOrderDTO.CustomerDTO.Id,
                OrderPrice = book.BookPrice,
                OrderQuantity = placeOrderDTO.Quantity,
                OrderTotal = book.BookPrice * placeOrderDTO.Quantity,
            };
            var isSaved=await Save(order);
            if (isSaved > 0)
            {
                book.BookQuantity -= placeOrderDTO.Quantity;
                await _bookService.Update(book);
                responseModel.Message = "Operation Successful";
                responseModel.IsError = false;
                responseModel.Id = placeOrderDTO.CustomerDTO.Id;
                return responseModel;
            }
            responseModel.Message = "Something went wrong";
            responseModel.IsError = true;
            return responseModel;
        }
        public async Task<IEnumerable<CustomerOrderDTO>> CustomerOrderHistory(int CustomerId)
        {
            return await _context.Orders
                .Include(f=>f.Customer)
                .Include(f=>f.Book)
                .ThenInclude(f=>f.Shope)
                .Where(f => f.CustomerId == CustomerId)
                .Select(f=>new CustomerOrderDTO
                {
                    CustomerName=f.Customer.CustomerName,
                    QuantityOrdered=f.OrderQuantity,
                    TotalCost=f.OrderTotal,
                    UnitCost=f.OrderPrice,
                    BookAuthor=f.Book.BookAuthor,
                    BookTitle=f.Book.BookTitle,
                    ShopName=f.Book.Shope.ShopName,
                    ShopState=f.Book.Shope.ShopState,
                    CustomerId=f.CustomerId
                })
                .ToListAsync();
        }

    }

}
