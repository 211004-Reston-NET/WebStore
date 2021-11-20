
//using BookStore.BL.DTO;
//using BookStore.BL.Services;
//using BookStore.BL.Services.Interfaces;
//using BookStore.DL.Entity;
//using Microsoft.EntityFrameworkCore;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BootStore.Test
//{
//    public class UnitTest2
//    {
//        private readonly DbContextOptions<StoreContext> options;

        
//        private static DbContextOptions<StoreContext> dbContextOptions = new DbContextOptionsBuilder<StoreContext>()
//            .UseInMemoryDatabase(databaseName: "BookDbTest")
//            .Options;

//        StoreContext context;

//        [OneTimeSetUp]
//        public void Setup()
//        {
//            context = new StoreContext(dbContextOptions);
//            context.Database.EnsureCreated();

//            SeedDatabase();
//        }

//        //UpdateBook
//        [Test]
//        public void UpdateBook()
//        {
//            using (var context = new BookDbTest(options))
//            {
//                //Arrange
//                var context = new StoreContext(options);
//                var bookService = new BookService(context);

//                var book = new BookDTO()
//                {
//                    BookId = 2,
//                    BookTitle = "Rich Dad, Poor Dad",
//                    BookAuthor = "Robort Kiaoski",
//                    Price = 43,
//                    Quantity = 20,
//                    ShopId = 1,

//                };

//                //Act
//                //Assert
//            }
//        }

//        [OneTimeTearDown]
//        public void CleanUp()
//        {
//            context.Database.EnsureDeleted();
//        }

//        private void SeedDatabase()
//        {
//            var customers = new List<Customer>
//            {
//                new Customer()
//                {
//                    CustomerId = 1,
//                    CustomerName = "Mickey Mouse"
//                },
//                new Customer()
//                {
//                    CustomerId = 2,
//                    CustomerName = "Balou"
//                },
//                new Customer()
//                {
//                    CustomerId = 3,
//                    CustomerName = "Mogli"
//                }
//            };
//            context.Customers.AddRange(customers);

//            var shops = new List<Shop>
//            {
//                new Shop()
//                {
//                    ShopId = 1,
//                    ShopName = "Dog BookShop",
//                    ShopState = "Texas"
//                },
//                new Shop()
//                {
//                    ShopId = 2,
//                    ShopName = "Cat BookShop",
//                    ShopState = "Louisiana"
//                },
//                new Shop()
//                {
//                    ShopId = 3,
//                    ShopName = "Fox BookShop",
//                    ShopState = "Montana"
//                }
//            };
//            context.Shops.AddRange(shops);

//            var books = new List<Book>
//            {
//                new Book()
//                {
//                    BookId = 1,
//                    BookTitle = "Dog",
//                    BookAuthor = "Eastwood",
//                    BookPrice = 1,
//                    BookQuantity = 200,
//                    ShopId = 1
//                },
//                new Book()
//                {
//                    BookId = 2,
//                    BookTitle = "Cat",
//                    BookAuthor = "Northwood",
//                    BookPrice = 2,
//                    BookQuantity = 250,
//                    ShopId = 2
//                },
//                new Book()
//                {
//                    BookId = 3,
//                    BookTitle = "Fox",
//                    BookAuthor = "Southwood",
//                    BookPrice = 1,
//                    BookQuantity = 300,
//                    ShopId = 3
//                }
//            };
//            context.Books.AddRange(books);

//            var orders = new List<Order>
//            {
//                new Order()
//                {
//                    OrderId = 1,
//                    OrderQuantity = 2,
//                    OrderPrice = 2,
//                    OrderTotal = 4,
//                    CustomerId = 1,
//                    BookId = 1
//                },
//                new Order()
//                {
//                    OrderId = 2,
//                    OrderQuantity = 2,
//                    OrderPrice = 3,
//                    OrderTotal = 6,
//                    CustomerId = 2,
//                    BookId = 2
//                },
//                new Order()
//                {
//                    OrderId = 3,
//                    OrderQuantity = 4,
//                    OrderPrice = 2,
//                    OrderTotal = 8,
//                    CustomerId = 3,
//                    BookId = 3
//                }
//            };
//            context.Orders.AddRange(orders);

//            context.SaveChanges();
//        }
//    }
//}
