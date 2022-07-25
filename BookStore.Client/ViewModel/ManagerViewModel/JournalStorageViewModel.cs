using BookStore.Models;
using BookStore.Server;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookStore.Client.ViewModel.ManagerViewModel
{
    public class JournalStorageViewModel : ViewModelBase
    {
        public ObservableCollection<Journal> JournalCollection { get; set; }
        public IEnumerable<Journal> Products { get; set; }
        private ProductsService productsService;

        private DelegateCommand<Journal> deleteCommand;
        public DelegateCommand<Journal> DeleteCommand =>
            deleteCommand ?? (deleteCommand = new DelegateCommand<Journal>(ExecuteDeleteCommand));

        public JournalStorageViewModel()
        {
            productsService = new ProductsService();
            MessengerInstance.Register<bool>(this, "journal", InitStorage);
            InitStorage(true);
        }
        private void ExecuteDeleteCommand(Journal journal)
        {
            JournalCollection.Remove(journal);
            productsService.RemoveJournal(journal);
        }
        private void InitStorage(bool b)
        {
            if (!b) return;
            Products = productsService.GetJournals();
            JournalCollection = new ObservableCollection<Journal>(Products);
        }
    }
}
