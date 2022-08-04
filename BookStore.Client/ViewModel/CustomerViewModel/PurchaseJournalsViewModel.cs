
using BookStore.Service.Context;
using BookStore.Service.Context.Models;
using BookStore.Service.Repositories.JournalRepo;
using BookStore.Service.Services.Cart;
using GalaSoft.MvvmLight;
using Prism.Commands;
using System.Collections.ObjectModel;

namespace BookStore.Client.ViewModel.CustomerViewModel
{
    //This is the viewmodel for adding journals to cart
    public class PurchaseJournalsViewModel : ViewModelBase
    {
        public ObservableCollection<Journal> JournalCollection { get; set; }

        private DelegateCommand<Journal> addToCartCommand;
        public DelegateCommand<Journal> AddToCartCommand =>
            addToCartCommand ?? (addToCartCommand = new DelegateCommand<Journal>(ExcecuteAddToCart));

        private readonly IJournalRepository journalRepository;
        private readonly ICart cart;
        public PurchaseJournalsViewModel(IJournalRepository journalRepository, ICart cart)
        {
            this.journalRepository = journalRepository;
            JournalCollection = new ObservableCollection<Journal>(this.journalRepository.GetAll());
            this.cart = cart;
        }
        private void ExcecuteAddToCart(Journal journal) => cart.Add(journal);
    }
}
