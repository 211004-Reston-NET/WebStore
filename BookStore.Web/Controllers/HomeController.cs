using BookStore.BL.DTO;
using BookStore.BL.Services.Interfaces;
using BookStore.DL.Entity;
using BookStore.Web.infrastructure;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
//using System.Web.Http;

namespace BookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IStoreInventoryService _shopService;
        private readonly ICustomerService _customerService;
        private readonly IStoreInventoryService _storeInventoryService;
        private readonly IOrderHistoryService _orderHistoryService;
        ServiceUtility _utiltiy;

        public HomeController(IBookService bookService,ServiceUtility utility,IStoreInventoryService shopService, ICustomerService customerService, IStoreInventoryService storeInventoryService, IOrderHistoryService orderHistoryService)
        {
            _bookService = bookService;
            _utiltiy = utility;
            _shopService = shopService;
            _customerService = customerService;
            _orderHistoryService = orderHistoryService;
            _storeInventoryService = storeInventoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> AddBook()
        {
          ViewBag.Shops= await  _utiltiy.GetShopSL();
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookDTO addBookDTO)
        {
            ViewBag.Shops = await _utiltiy.GetShopSL();
            if (ModelState.IsValid)
            {
                await _bookService.AddBook(addBookDTO);
            }
            return RedirectToAction("BookList");
        }
        public IActionResult AddShop()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddShop(AddShopDTO addShopDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _shopService.AddShop(addShopDTO);
                if (response)
                    return RedirectToAction("ShopList");
                else
                    return View(addShopDTO);
            }
            return View(addShopDTO);
        }
        public async Task<IActionResult> ShopList()
        {
            return View(await _shopService.GetAllShops());
        }
        public async Task<IActionResult> BookList()
        {
            return View(await _bookService.GetAllBooks());
        }
        public async Task<IActionResult> EditBook(int bookId)
        {
            ViewBag.Shops = await _utiltiy.GetShopSL();
            var book=await _bookService.GetBookBy(bookId);
            if (book == null)
                return NotFound();
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> EditBook(BookDTO bookDTO)
        {
            ViewBag.Shops = await _utiltiy.GetShopSL();
            if (ModelState.IsValid)
            {
                var response=await _bookService.UpdateBook(bookDTO);
                if (response)
                    return RedirectToAction("BookList");
                else
                    return View(bookDTO);
            }
            return View(bookDTO);
        }
        /*------------------------------------------------------------------*/

        //Store Inventory by shopId
        public async Task<IActionResult> GetInventory(int shopId)
        {
            ViewBag.Shops = await _utiltiy.GetShopSL();
            var books = await _storeInventoryService.GetShopInventory(shopId);
            if (books == null)
                return NotFound();
            return View(books);

            //return View(await _storeInventoryService.GetShopInventory(shopId));
        }

        //Get All Customers
        public async Task<IActionResult> CustomerList()
        {
            return View(await _customerService.GetAllCustomers());
        }
        //Add Customer
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerDTO addCustomerDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _customerService.AddCustomer(addCustomerDTO);
                if (response)
                    return RedirectToAction("CustomerList");
                else
                    return View(addCustomerDTO);
            }
            return View(addCustomerDTO);
        }

        //Find Customer
        //Customer Order History
        public async Task<IActionResult> GetOrderHistory(int customerId)
        { 
            var order = await _orderHistoryService.FindCustomerOrder(customerId);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        //Edit Customer
        public async Task<IActionResult> EditCustomer(int customerId)
        {
            var customerDetails = await _customerService.GetCustomerById(customerId);
            if (customerDetails == null)
            {
                return View("NotFound");
            }
            return View(customerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> EditCustomer(CustomerDTO customerDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _customerService.UpdateCustomer(customerDTO);
                if (response)
                    return RedirectToAction("CustomerList");
                else
                    return View(customerDTO);
            }
            return View(customerDTO);
        }
        //Delete Customer
        public async Task<IActionResult> Delete(int id)
        {
            var custDetails = await _customerService.GetCustomerById(id);
            if (custDetails == null)
            {
                return View("NotFound");
            }
            return View(custDetails);
        }

        //HttpPost
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var custDetails = await _customerService.GetCustomerById(id);
            if (custDetails == null)
            {
                return View("NotFound");
            }
            await _customerService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //Place an Order or make a Purchase
        public async Task<IActionResult> PlaceOrder(int customerId)
        {
            PlaceOrderDTO placeOrderDTO = new PlaceOrderDTO();
            ViewBag.Books = await _utiltiy.GetBookSL();
            placeOrderDTO.CustomerDTO=await _customerService.GetCustomerById(customerId);
            if (placeOrderDTO.CustomerDTO != null)
                return View(placeOrderDTO);
            else
                return RedirectToAction("CustomerList");

        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(PlaceOrderDTO placeOrderDTO)
        {
            ViewBag.Books = await _utiltiy.GetBookSL();
            if (ModelState.IsValid)
            {
                var response=await _orderHistoryService.PlaceOrder(placeOrderDTO);
                if (response.IsError)
                {
                    TempData["error"] = response.Message;
                    return View(placeOrderDTO);
                }
                else
                    return RedirectToAction("CustomerOrderList", new { customerId = response.Id });
                    
            }
            return View(placeOrderDTO);

        }
        public async Task<IActionResult> CustomerOrderList(int customerId)
        {
            return View(await _orderHistoryService.CustomerOrderHistory(customerId));
        }
        public IActionResult FindCustomerByName()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FindCustomerByName(string name)
        {
            
            return View(await _customerService.GetCustomersBy(name));
            
        }
        public IActionResult FindBookByName()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FindBookByName(string name)
        {
            
            return View(await _bookService.FindBookByName(name));
        }




    }
}