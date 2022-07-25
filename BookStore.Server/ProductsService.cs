using BookStore.Data;
using BookStore.Data.Interfaces;
using BookStore.Models;
using BookStore.Models.Enums;
using BookStore.Server.Managers;
using System;
using System.Collections.Generic;

namespace BookStore.Server
{
    //This class is a מתווך between the UI and Data
    public class ProductsService
    {
        private readonly IRepository<ProductBase> repository;
        private readonly BookManager bookManager;
        private readonly JournalManager journalManager;
        public ProductsService()
        {
            bookManager = new BookManager();
            journalManager = new JournalManager();
            repository = RepositoryFactory.GetProductRepository();
        }
        public IEnumerable<ProductBase> GetProducts() => repository.Get();
        public IEnumerable<Journal> GetJournals() => journalManager.GetJournals();
        public void AddJournal(string title, string editorName, int issueNumber, DateTime publicationDate,
            decimal basePrice, JournalFrequency frequency, params JournalGenre[] genres) =>
            journalManager.AddJournal(title, editorName, issueNumber, publicationDate, basePrice, frequency, genres);
        public void RemoveJournal(Journal journal) => journalManager.RemoveJournal(journal);
        public IEnumerable<Book> GetBooks() => bookManager.GetBooks();
        public void RemoveBook(Book book) => bookManager.RemoveBook(book);
        public void UpdateBook(Book book) => bookManager.UpdateBook(book);
        public void AddBook(string title, string author, DateTime publicationDate, decimal price,
            int edition = 1, string summary = null, string imageSource = null, params BookGenre[] genres) =>
            bookManager.AddBook(title, author, publicationDate, price, edition, summary, imageSource, genres);
    }
}
