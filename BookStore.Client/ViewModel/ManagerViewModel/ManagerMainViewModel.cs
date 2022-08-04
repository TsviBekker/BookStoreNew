using BookStore.Client.View;
using BookStore.Client.View.ManagerViews;
using BookStore.Service.Repositories.BookRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel.ManagerViewModel
{
    public class ManagerMainViewModel : ViewModelBase
    {
        //this is the toolbar viewmodel. it is only used to update the view depending on what user chose
        private UserControl currentContent;
        public UserControl CurrentContent { get => currentContent; set => Set(ref currentContent, value); }

        public RelayCommand ReviewBooksCommand { get; set; }
        public RelayCommand AddBooksCommand { get; set; }
        public RelayCommand AddJournalsCommand { get; set; }
        public RelayCommand ReviewJournalsCommand { get; set; }
        public RelayCommand ReturnCommand { get; set; }
        public ManagerMainViewModel()
        {
            ReviewBooksCommand = new RelayCommand(
                () => CurrentContent = new ManagerStorageView());

            AddJournalsCommand = new RelayCommand(
                () => CurrentContent = new AddJournalsView());

            ReviewJournalsCommand = new RelayCommand(
                () => CurrentContent = new JournalStorageView());

            ReturnCommand = new RelayCommand(
                    () => MessengerInstance.Send<UserControl>(new PrimaryView()));

            AddBooksCommand = new RelayCommand(
                () =>
                {
                    MessengerInstance.Send(true, "reset");
                    CurrentContent = new AddBooksView();
                });
        }
    }
}
