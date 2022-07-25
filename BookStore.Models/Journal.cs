using BookStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models
{
    [Serializable]
    public class Journal : ProductBase
    {
        public int IssueNumber { get; set; } //מספר גיליון
        public string EditorName { get; set; }
        public string Name { get => base.Description; set => base.Description = value; }
        public JournalFrequency JournalFrequency { get; set; }
        public ICollection<JournalGenre> Genres { get; set; }
        public string GenresAsString { get; set; }
        //Ctor
        public Journal(string description, string editorName, int issueNumber,
            DateTime publicationDate, decimal basePrice, JournalFrequency frequency, params JournalGenre[] genres)
            : base(description, publicationDate, basePrice)
        {
            JournalFrequency = frequency;
            EditorName = editorName;
            IssueNumber = issueNumber;
            ObjectType = 2;
            Genres = genres.ToList();
        }
    }
}
