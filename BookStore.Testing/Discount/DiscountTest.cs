using BookStore.Service.Context.Models;
using BookStore.Service.Services.Cart.Discount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Testing.Discount
{
    [TestClass]
    public class DiscountTest
    {
        private readonly DiscountService discountService;
        public IEnumerable<ProductBase> Products { get; set; }
        public DiscountTest()
        {
            discountService = new DiscountService();
            Products = new List<ProductBase>()
            {
                new Book()
                {
                    Id = 1,
                    AuthorName ="A",
                    BasePrice = 10
                },
                new Book()
                {
                    Id = 2,
                    AuthorName ="B",
                    BasePrice = 20
                },
                new Journal()
                {
                    Id=3,
                    EditorName="C",
                    BasePrice=30
                }
            };
        }

        [TestMethod]
        public void Basic_Test_Three_Items()
        {
            var discount = discountService.CalcDiscount(Products);
            Assert.AreEqual(discount, Products.Min(x => x.BasePrice));
            Assert.AreEqual(discount, 10); //Hard coded
        }

        [TestMethod]
        public void Basic_Test_Six_Items()
        {
            Products.ToList().AddRange(Products);
            var discount = discountService.CalcDiscount(Products);
            Assert.AreEqual(discount, Products.Min(x => x.BasePrice));
            Assert.AreEqual(discount, 10); //Hard coded
        }

        [TestMethod]
        public void NoDiscount_Test()
        {
            var discount = discountService.CalcDiscount(Products.Take(2));
            Assert.AreEqual(decimal.Zero, discount);
        }
    }
}
