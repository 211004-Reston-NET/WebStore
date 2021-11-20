using BookStore.BL.DTO;
using BookStore.BL.Services;
using BookStore.DL.Entity;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BootStore.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var bookService = new BookService(context);

            var book = new AddBookDTO()
            {
                BookAuthor = "Stephan King",
                BookTitle = "The Shining"
            };
            // Act
            var result = bookService.AddBook(book);

            var bookRecord = context.Books.Find(1);
            // Assert
            Assert.IsNotNull(bookRecord);

        }

        [Test]
        public void GetBookBy()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var bookService = new BookService(context);
            //Act
            var data = bookService.GetBookBy(2);
            //Assert
            Assert.IsNotNull(data);

        }
        [Test]
        public void GetAllBooks()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var bookService = new BookService(context);
            //Act
            var getBooks = bookService.GetAllBooks();
            //Assert
            Assert.IsNotNull(getBooks);

        }

        /*------------------------------------------------------------*/
        //Get book by BookTitle
        [Test]
        public void Test_GetBookBy()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;
            var context = new StoreContext(options);
            var bookService = new BookService(context);
            //Act
            var data = bookService.GetBookBy("Rich Dad Poor Dad");
            //Assert
            Assert.IsNotNull(data);
        }

        /*------------------------------------------------------------*/
        //Get book by BookAuthor
        [Test]
        public void FindBookByName()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;
            var context = new StoreContext(options);
            var bookService = new BookService(context);
            //Act
            var data = bookService.FindBookByName("A Dog without purpose");
            //Assert
            Assert.IsNotNull(data);
        }

        /*------------------------------------------------------------*/
        //Add Customer
        [Test]
        public void AddCustomer()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var customerService = new CustomerService(context);

            var customer = new AddCustomerDTO()
            {
                Name = "King",
            };
            // Act
            var result = customerService.AddCustomer(customer);

            var customerRecord = context.Customers.Find(1);
            // Assert
            Assert.IsNotNull(customerRecord);
        }

        /*------------------------------------------------------------*/
        //GetCustomersBy---It gets a customer by name
        [Test]
        public void GetCustomersByName()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;
            var context = new StoreContext(options);
            var customerService = new CustomerService(context);
            //Act
            var data = customerService.GetCustomersBy("Peter");
            //Assert
            Assert.IsNotNull(data);
        }

        /*------------------------------------------------------------*/
        //GetCustomerById---It gets a customer by Id
        [Test]
        public void GetCustomerById()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var customerService = new CustomerService(context);
            //Act
            var data = customerService.GetCustomerById(1);
            //Assert
            Assert.IsNotNull(data);
        }

        /*------------------------------------------------------------*/
        /*------------------------------------------------------------*/
        ////Delete---Delete Customer
        //[Test]
        //public void Delete()
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<StoreContext>()
        //        .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
        //        .Options;

        //    var context = new StoreContext(options);
        //    var customerService = new CustomerService(context);
        //    //Act
        //    var data = customerService.Delete(1);
        //    //Assert
        //    Assert.IsNull(data);
        //}
        //UpdateCustomer
        //[Test]
        //public void UpdateCustomer()
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<StoreContext>()
        //        .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
        //        .Options;

        //    var context = new StoreContext(options);
        //    var customerService = new CustomerService(context);

        //    var customer = new CustomerDTO()
        //    {
        //        Id = 3,
        //        Name = "Mogli"
        //    };

        //    // Act
        //    var result = customerService.UpdateCustomer(customer);
        //    context.SaveChanges();
        //    var customerRecord = context.Customers.Find(3);
        //    // Assert
        //    Assert.IsNotNull(customerRecord);
        //}

        /*------------------------------------------------------------*/
        //UpdateBook
        //[Test]
        //public void UpdateBook()
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<StoreContext>()
        //        .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
        //        .Options;

        //    var context = new StoreContext(options);
        //    var bookService = new BookService(context);

        //    var book = new BookDTO()
        //    {
        //        BookId = 2,
        //        BookTitle = "Rich Dad, Poor Dad",
        //        BookAuthor = "Robort Kiaoski",
        //        Price = 43,
        //        Quantity = 20,
        //        ShopId = 1,

        //    };
        //    var result = bookService.AddBook(book);

        //    var book = new BookDTO()
        //    {
        //        BookId = 2,
        //    }

        //    // Act
        //    var result = bookService.UpdateBook(book);

        //    var bookRecord = context.Books.Find(2);
        //    // Assert
        //    Assert.IsNotNull(bookRecord);
        //}
        /*------------------------------------------------------------*/
        //GetAllCustomers
        [Test]
        public void GetAllCustomers()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var customerService = new CustomerService(context);
            //Act
            var getCustomers = customerService.GetAllCustomers();
            //Assert
            Assert.IsNotNull(getCustomers);

        }
        /*------------------------------------------------------------*/
        [Test]
        public void CustomerOrderHistory()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var orderHistoryService = new OrderHistoryService(context);
            //Act
            var data = orderHistoryService.CustomerOrderHistory(2);
            //Assert
            Assert.IsNotNull(data);

        }
        /*------------------------------------------------------------*/
        //AddShop
        [Test]
        public void AddShop()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookShopDatabase")
                .Options;

            var context = new StoreContext(options);
            var storeInventoryService = new StoreInventoryService(context);

            var shop = new AddShopDTO()
            {
                ShopName = "Monopree BookShop",
                ShopState = "North Carolina"
            };
            // Act
            var result = storeInventoryService.AddShop(shop);

            var shopRecord = context.Shops.Find(1);

            // Assert
            Assert.IsNotNull(shopRecord);
        }

        /*------------------------------------------------------------*/
        //GetShopInventory by shopId
        [Test]
        public void GetShopInventory()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var storeInventoryService = new StoreInventoryService(context);
            //Act
            var data = storeInventoryService.GetShopInventory(1);
            //Assert
            Assert.IsNotNull(data);
        }

        /*------------------------------------------------------------*/
        //GetAllCustomers
        [Test]
        public void GetAllShops()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var storeInventoryService = new StoreInventoryService(context);
            //Act
            var getShops = storeInventoryService.GetAllShops();
            //Assert
            Assert.IsNotNull(getShops);

        }

        /*------------------------------------------------------------*/
        //FindCustomerOrder
        [Test]
        public void FindCustomerOrder()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var orderHistoryService = new OrderHistoryService(context);

            //Act
            var findCustomerOrder = orderHistoryService.FindCustomerOrder(1);

            //Assert
            Assert.IsNotNull(findCustomerOrder);
        }

        /*------------------------------------------------------------*/
        //GetOrder
        [Test]
        public void GetOrder()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "BookStoreDatabase")
                .Options;

            var context = new StoreContext(options);
            var orderHistoryService = new OrderHistoryService(context);

            //Act
            var getOrder = orderHistoryService.GetOrder(1);

            //Assert
            Assert.IsNotNull(getOrder);
        }

        /*------------------------------------------------------------*/
        
    }
}

