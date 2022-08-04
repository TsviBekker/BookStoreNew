using BookStore.Service.Context.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Service.Context.Models
{
    public class Book : ProductBase
    {
        public string AuthorName { get; set; }
        public string Title { get => base.Description; set => base.Description = value; }
        public BookGenre Genre { get; set; }
        public int Edition { get; set; }
        public string Summary { get; set; }
    }
}
