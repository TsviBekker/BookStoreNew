using BookStore.Models;
using BookStore.Server;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookStore.Client.ViewModel.EmployeeViewModel
{
    public class EmployeeJournalStorageViewModel : ViewModelBase
    {
        public ObservableCollection<Journal> JournalCollection { get; set; }
        public IEnumerable<Journal> Products { get; set; }
        private ProductsService productsService;
        public EmployeeJournalStorageViewModel()
        {
            productsService = new ProductsService();
            MessengerInstance.Register<bool>(this, "journal", InitStorage);
            InitStorage(true);
        }
        private void InitStorage(bool b)
        {
            if (!b) return;
            Products = productsService.GetJournals();
            JournalCollection = new ObservableCollection<Journal>(Products);
        }
    }
}
