using BookStore.Service.Context.Models;
using BookStore.Service.Services.Cart;
using BookStore.Service.Services.Cart.Discount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace BookStore.Testing.Cart
{
    [TestClass]
    public class CartTest
    {
        private readonly ICart cart;
        public CartTest()
        {
            var mock = new Mock<DiscountService>();

            cart = new Service.Services.Cart.Cart(mock.Object);

            cart.Add(new Book() { Id = 1, Title = "A", BasePrice = 10 });
            cart.Add(new Journal() { Id = 2, Name = "J", BasePrice = 20 });
            cart.Add(new Book() { Id = 3, Title = "B", BasePrice = 30 });
            cart.Add(new Book() { Id = 4, Title = "C", BasePrice = 40 });
        }

        [TestMethod]
        public void Basic_Test_Add_Remove_Empty()
        {
            Assert.AreEqual(4, cart.ShoppingCart.Count);

            cart.Remove(cart.ShoppingCart[0]);
            Assert.AreEqual(3, cart.ShoppingCart.Count);

            cart.Empty();
            Assert.AreEqual(0, cart.ShoppingCart.Count);
        }

        [TestMethod]
        public void Discount_Test()
        {
            var discount = cart.Discount;
            var min = cart.ShoppingCart.Min(a => a.BasePrice);
            Assert.AreEqual(min, discount);
        }

        [TestMethod]
        public void Total_Test()
        {
            var total = cart.Total;
            var priceSum = cart.ShoppingCart.Aggregate(decimal.Zero, (acc, curr) => acc + curr.BasePrice);
            var expected = priceSum - cart.Discount;

            Assert.AreEqual(total, expected);
        }

        [TestMethod]
        public void No_Discount_Test()
        {
            cart.ShoppingCart.Remove(cart.ShoppingCart[0]);
            cart.ShoppingCart.Remove(cart.ShoppingCart[0]);
            var discount = cart.Discount;

            Assert.AreEqual(decimal.Zero, discount);
        }
    }
}
