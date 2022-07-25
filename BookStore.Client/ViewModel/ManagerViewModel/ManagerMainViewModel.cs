using BookStore.Client.View;
using BookStore.Client.View.ManagerViews;
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
            ReviewBooksCommand = new RelayCommand(ReviewBooks);
            AddBooksCommand = new RelayCommand(AddBooks);
            AddJournalsCommand = new RelayCommand(AddJournals);
            ReviewJournalsCommand = new RelayCommand(ReviewJournals);
            ReturnCommand = new RelayCommand(Return);
        }
        private void Return() => MessengerInstance.Send<UserControl>(new PrimaryView());
        private void ReviewJournals()
        {
            MessengerInstance.Send<bool>(true,"journal");
            CurrentContent = new JournalStorageView();
        }
        private void AddJournals() => CurrentContent = new AddJournalsView();
        private void AddBooks()
        {
            MessengerInstance.Send<bool>(true, "reset");
            CurrentContent = new AddBooksView();
        }

        private void ReviewBooks()
        {
            MessengerInstance.Send<bool>(true,"book");
            CurrentContent = new ManagerStorageView();
        }
    }
}
