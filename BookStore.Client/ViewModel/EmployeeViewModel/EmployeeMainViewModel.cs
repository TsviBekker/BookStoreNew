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

        //Ctor
        public EmployeeMainViewModel()
        {
            ReturnCommand = new RelayCommand(() => MessengerInstance.Send<UserControl>(new PrimaryView()));

            ReviewBooksCommand = new RelayCommand(() => CurrentContent = new EmployeeBookStorageView());
            ReviewJournalsCommand = new RelayCommand(() => CurrentContent = new EmployeeJournalStorageView());
        }
    }
}
