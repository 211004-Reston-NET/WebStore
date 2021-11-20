using BookStore.BL.DTO;
using BookStore.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Services.Interfaces
{
    public interface ICustomerService:IRepository<Customer>
    {

        Task<IEnumerable<CustomerDTO>> GetAllCustomers();
        Task<CustomerDTO> GetCustomerById(int Id);
        Task<bool> AddCustomer(AddCustomerDTO addCustomerDTO);
        Task Delete(int id);
        Task<bool> UpdateCustomer(CustomerDTO customerDTO);
        Task<CustomerDTO> GetCustomersBy(string name);
    }
}
