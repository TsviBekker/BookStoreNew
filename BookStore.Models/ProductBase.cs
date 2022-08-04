using BookStore.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    [Serializable()]
    public abstract class ProductBase : IDataEntity
    {
        public int ObjectType { get; set; }
        [Required]
        public Guid Id { get; internal set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal BasePrice { get; set; }
        public string ProductImageSource { get; set; }
        //Ctor1
        protected ProductBase(string description, DateTime publicationDate, decimal basePrice)
            : this(Guid.NewGuid(), description, publicationDate, basePrice) { }
        //Ctor2
        internal ProductBase(Guid id, string description, DateTime publicationDate, decimal basePrice)
        {
            this.Id = id;
            this.Description = description;
            this.PublicationDate = publicationDate;
            this.BasePrice = basePrice;
        }
    }
}
