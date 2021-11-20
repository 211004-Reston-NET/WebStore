using BookStore.BL.DTO;
using BookStore.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BookStore.BL.Services.Interfaces
{
    public interface IOrderHistoryService : IRepository<Order>
    {
        Task<IEnumerable<OrderDTO>> FindCustomerOrder(int custId);
        Task<ResponseModel> PlaceOrder(PlaceOrderDTO placeOrderDTO);
        Task<IEnumerable<CustomerOrderDTO>> CustomerOrderHistory(int CustomerId);

    }
}
