using BookStore.Service.Context.Models;
using BookStore.Service.Repositories.JournalRepo;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace BookStore.Client.ViewModel.ManagerViewModel
{
    public class JournalStorageViewModel : ViewModelBase
    {
        private DelegateCommand<Journal> deleteCommand;
        public DelegateCommand<Journal> DeleteCommand =>
            deleteCommand ?? (deleteCommand = new DelegateCommand<Journal>(ExecuteDeleteCommand));

        public ObservableCollection<Journal> JournalCollection { get; set; }

        private readonly IJournalRepository journalRepository;

        public JournalStorageViewModel(IJournalRepository journalRepository)
        {
            this.journalRepository = journalRepository;
            JournalCollection = new ObservableCollection<Journal>(journalRepository.GetAll());
        }

        private async void ExecuteDeleteCommand(Journal journal)
        {
            JournalCollection.Remove(journal);

            await journalRepository.Delete(journal.Id);
        }
    }
}
