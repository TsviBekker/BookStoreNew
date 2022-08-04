using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Service.Context.Models
{
    public abstract class ProductBase
    {
        [Required]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal BasePrice { get; set; }
        public string ProductImageSource { get; set; }
    }
}
