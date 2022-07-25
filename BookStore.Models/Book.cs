using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models
{
    [Serializable]
    public class Book : ProductBase
    {
        public string AuthorName { get; set; }
        public string Title { get => base.Description; set => base.Description = value; }
        public ICollection<BookGenre> Genres { get; set; }
        public int Edition { get; set; }
        public string Summary { get; set; }
        public string GenresAsString { get; set; }
        //Ctor
        public Book(string authorName, string description, DateTime publicationDate,
            decimal basePrice, int edition = 1, params BookGenre[] genres)
            : base(description, publicationDate, basePrice)
        {
            AuthorName = authorName;
            Edition = edition;
            ObjectType = 1;
            Genres = genres.ToList();
        }
    }
}
