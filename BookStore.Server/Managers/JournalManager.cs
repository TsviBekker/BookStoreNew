using BookStore.Data;
using BookStore.Data.Interfaces;
using BookStore.Models;
using BookStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Server.Managers
{
    internal class JournalManager
    {
        private readonly IRepository<ProductBase> repository;
        public JournalManager()
        {
            repository = RepositoryFactory.GetProductRepository();
        }
        public IEnumerable<Journal> GetJournals()
        {
            var journals = new List<Journal>();
            foreach (var item in repository.Get())
            {
                if (item.GetType().Equals(typeof(Journal)))
                    journals.Add((Journal)item);
            }
            return journals;
        }
        public void AddJournal(string title, string editorName, int issueNumber, DateTime publicationDate,
                  decimal basePrice, JournalFrequency frequency, params JournalGenre[] genres)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < genres.Length; i++)
            {
                sb.Append(genres[i]);
                if (i < genres.Length - 1)
                    sb.Append(", ");
            }
            Journal journal = new Journal(title, editorName, issueNumber, publicationDate, basePrice, frequency, genres)
            { GenresAsString = sb.ToString() };
            repository.Insert(journal);
            repository.Dispose();
        }
        public void RemoveJournal(Journal journal)
        {
            repository.Delete(journal.Id);
            repository.Dispose();
        }
    }
}
