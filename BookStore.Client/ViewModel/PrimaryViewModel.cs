using BookStore.Client.View.CustomerViews;
using BookStore.Client.View.ManagerViews;
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
            CustomerCommand = new RelayCommand(CustomerSelected);
            EmployeeCommand = new RelayCommand(EmployeeSelected);

        }
        private void EmployeeSelected() => PasswordView = new PasswordView();
        private void CustomerSelected() => MessengerInstance.Send<UserControl>(new CustomerMainView());
    }
}
