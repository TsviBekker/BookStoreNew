using BookStore.Service.Context.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Context.Models
{
    public class Journal : ProductBase
    {
        public int IssueNumber { get; set; } //מספר גיליון
        public string EditorName { get; set; }
        public string Name { get => base.Description; set => base.Description = value; }
        public JournalFrequency JournalFrequency { get; set; }
        public JournalGenre Genre { get; set; }
    }
}
