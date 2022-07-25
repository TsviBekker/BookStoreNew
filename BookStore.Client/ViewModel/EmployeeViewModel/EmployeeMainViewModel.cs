using BookStore.Client.View;
using BookStore.Client.View.EmployeeViews;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel.EmployeeViewModel
{
    public class EmployeeMainViewModel : ViewModelBase
    {
        private UserControl currentContent;
        public UserControl CurrentContent { get => currentContent; set => Set(ref currentContent, value); }
        public RelayCommand ReviewBooksCommand { get; set; }
        public RelayCommand ReviewJournalsCommand { get; set; }
        public RelayCommand ReturnCommand { get; set; }
        public EmployeeMainViewModel()
        {
            ReviewBooksCommand = new RelayCommand(ReviewBooks);
            ReviewJournalsCommand = new RelayCommand(ReviewJournals);
            ReturnCommand = new RelayCommand(Return);
        }
        private void Return() => MessengerInstance.Send<UserControl>(new PrimaryView());
        private void ReviewJournals()
        {
            MessengerInstance.Send<bool>(true, "journal");
            CurrentContent = new EmployeeJournalStorageView();
        }
        private void ReviewBooks()
        {
            MessengerInstance.Send<bool>(true, "book");
            CurrentContent = new EmployeeBookStorageView();
        }
    }
}
