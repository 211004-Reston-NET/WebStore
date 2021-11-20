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
    public class CustomerService : Repository<Customer>, ICustomerService
    {
        public CustomerService(StoreContext context)
            : base(context)
        {

        }

        //Add a Customer
        public async Task<bool> AddCustomer(AddCustomerDTO addCustomerDTO)
        {
            Customer customer = new Customer()
            {
                CustomerName = addCustomerDTO.Name
            };
            var isCreated = await Save(customer);
            if (isCreated > 0)
                return true;
            return false;
        }

        public async Task Delete(int id)
        {
            var customer=await GetBy(f => f.CustomerId == id);
            if(customer!=null)
            await Delete(customer);
        }


        //GetAllCustomers
        public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
        {
            return await _context.Customers
                .Select(f => new CustomerDTO
                {
                    //Properties from CustomerDTO = f.Customer.cs Properties
                    Id = f.CustomerId,
                    Name = f.CustomerName
                })
                .ToListAsync();
        }
        
        
        //Get A Customer By Id
        public async Task<CustomerDTO> GetCustomerById(int Id)
        {
            return await _context.Customers.Where(f => f.CustomerId == Id)
                .Select(f => new CustomerDTO
                {
                    //Properties from CustomerDTO = f.Customer.cs Properties
                    Id = f.CustomerId,
                    Name = f.CustomerName
                })
                .FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateCustomer(CustomerDTO customerDTO)
        {
            if (customerDTO?.Id > 0)
            {
                var customerExist = await _context.Customers.Where(f => f.CustomerId == customerDTO.Id).FirstOrDefaultAsync();
                if (customerExist?.CustomerId > 0)
                {
                    customerExist.CustomerName = customerDTO.Name;
                    await Update(customerExist);
                    return true;
                }
            }
            return false;
        }
        public async Task<CustomerDTO> GetCustomersBy(string name)
        {
            return await _context.Customers
                .Where(f => f.CustomerName.ToLower() == name.ToLower())
                .Select(f=>new CustomerDTO
                {
                    Id=f.CustomerId,
                    Name=f.CustomerName
                })
                .FirstOrDefaultAsync();
        }



    }
}
