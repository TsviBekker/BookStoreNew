using BookStore.Client.ViewModel.ManagerViewModel;
using BookStore.Service.Context;
using BookStore.Service.Repositories.BookRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BookStore.Testing.ViewModels
{
    [TestClass]
    public class AddBooksViewModelTests
    {
        private readonly AddBooksViewModel viewModel;
        public AddBooksViewModelTests()
        {
            var context = new Mock<BookStoreContextFactory>();
            var repo = new Mock<BookRepository>(context.Object);
            viewModel = new AddBooksViewModel(repo.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
