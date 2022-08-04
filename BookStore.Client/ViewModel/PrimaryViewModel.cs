using BookStore.Client.View.CustomerViews;
using BookStore.Client.View.ManagerViews;
using BookStore.Client.ViewModel.CustomerViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel
{
    public class PrimaryViewModel : ViewModelBase
    {
        private UserControl passwordView;
        public UserControl PasswordView { get => passwordView; set => Set(ref passwordView, value); }

        public RelayCommand CustomerCommand { get; set; }
        public RelayCommand EmployeeCommand { get; set; }

        public PrimaryViewModel()
        {
            CustomerCommand = new RelayCommand(() => MessengerInstance.Send<UserControl>(new CustomerMainView()));
            EmployeeCommand = new RelayCommand(() => PasswordView = new PasswordView());
        }
    }
}
