using BookStore.Service.Context.Models;
using BookStore.Service.Repositories.JournalRepo;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookStore.Client.ViewModel.EmployeeViewModel
{
    public class EmployeeJournalStorageViewModel : ViewModelBase
    {
        public ObservableCollection<Journal> JournalCollection { get; set; }
        public IEnumerable<Journal> Products { get; set; }
        private readonly IJournalRepository journalRepository;

        public EmployeeJournalStorageViewModel(IJournalRepository journalRepository)
        {
            this.journalRepository = journalRepository;
            JournalCollection = new ObservableCollection<Journal>(this.journalRepository.GetAll());
        }
    }
}
