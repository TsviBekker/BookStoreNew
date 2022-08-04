using BookStore.Service.Context.Models;
using BookStore.Service.Context.Models.Enums;
using System;
using System.Data.Entity;

namespace BookStore.Service.Context
{
    public class BookStoreContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Journal> Journals { get; set; }

        public BookStoreContext(string dbConnectionString = "BookStoreContext") : base(dbConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
