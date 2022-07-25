using BookStore.Data;
using BookStore.Data.Interfaces;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Server.Managers
{
    internal class BookManager
    {
        private readonly IRepository<ProductBase> repository;
        public BookManager()
        {
            repository = RepositoryFactory.GetProductRepository();
        }
        public void AddBook(string title, string author, DateTime publicationDate, decimal price,
               int edition = 1, string summary = null, string imgSource = null, params BookGenre[] genres)
        {
            Book book = new Book(author, title, publicationDate, price, edition, genres)
            { Summary = summary, GenresAsString = InitGenresAsString(genres), ProductImageSource = imgSource };
            repository.Insert(book); //insert
            repository.Dispose(); //update the JSON file
        }
        public void RemoveBook(Book book)
        {
            repository.Delete(book.Id); //delete
            repository.Dispose(); //update JSON
        }
        public IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>(); 
            foreach (var item in repository.Get())
            {
                if (item.GetType().Equals(typeof(Book)))
                    books.Add((Book)item); 
            }
            return books;
        }
        internal void UpdateBook(Book book)
        {
            book.GenresAsString = InitGenresAsString(book.Genres.ToArray());
            repository.Update(book);
            repository.Dispose();
        }
        private string InitGenresAsString(params BookGenre[] genres)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < genres.Length; i++)
            {
                sb.Append(genres[i]);
                if (i < genres.Length - 1)
                    sb.Append(", ");
            }
            return sb.ToString();
        }
    }
}
