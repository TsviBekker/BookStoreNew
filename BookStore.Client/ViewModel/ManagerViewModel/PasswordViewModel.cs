using BookStore.Client.View.EmployeeViews;
using BookStore.Client.View.ManagerViews;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel.ManagerViewModel
{
    public class PasswordViewModel : ViewModelBase
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public RelayCommand EnterCommand { get; set; }
        public PasswordViewModel()
        {
            EnterCommand = new RelayCommand(Enter);
        }
        private void Enter()
        {
            if (Username == null || Password == null)
                return;
            if (Username.ToLower() == "employee" && Password == "123")
            {
                MessengerInstance.Send<UserControl>(new EmployeeMainView());
            }
            else if (Username.ToLower() == "admin" && Password == "123")
            {
                MessengerInstance.Send<UserControl>(new ManagerMainView());
            }
            else
            {
                MessageBox.Show("Incorrect Password/Username");
            }
        }
    }
}
