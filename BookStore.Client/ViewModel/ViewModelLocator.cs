
using BookStore.Client.ViewModel.CustomerViewModel;
using BookStore.Client.ViewModel.EmployeeViewModel;
using BookStore.Client.ViewModel.ManagerViewModel;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace BookStore.Client.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PrimaryViewModel>();
            SimpleIoc.Default.Register<PasswordViewModel>();
            SimpleIoc.Default.Register<ManagerMainViewModel>();
            SimpleIoc.Default.Register<BookStorageViewModel>();
            SimpleIoc.Default.Register<AddBooksViewModel>();
            SimpleIoc.Default.Register<AddJournalsViewModel>();
            SimpleIoc.Default.Register<JournalStorageViewModel>();
            SimpleIoc.Default.Register<EmployeeMainViewModel>();
            SimpleIoc.Default.Register<EmployeeBookStorageViewModel>();
            SimpleIoc.Default.Register<EmployeeJournalStorageViewModel>();
            SimpleIoc.Default.Register<CustomerMainViewModel>();
            SimpleIoc.Default.Register<PurchaseBooksViewModel>();
            SimpleIoc.Default.Register<PurchaseJournalsViewModel>();
            SimpleIoc.Default.Register<ShoppingCartViewModel>();
        }
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public AddBooksViewModel AddBooks => ServiceLocator.Current.GetInstance<AddBooksViewModel>();
        public PrimaryViewModel PrimaryView => ServiceLocator.Current.GetInstance<PrimaryViewModel>();
        public PasswordViewModel PasswordView => ServiceLocator.Current.GetInstance<PasswordViewModel>();
        public ManagerMainViewModel ManagerMainView => ServiceLocator.Current.GetInstance<ManagerMainViewModel>();
        public BookStorageViewModel BookStorage => ServiceLocator.Current.GetInstance<BookStorageViewModel>();
        public AddJournalsViewModel AddJournals => ServiceLocator.Current.GetInstance<AddJournalsViewModel>();
        public JournalStorageViewModel JournalStorage => ServiceLocator.Current.GetInstance<JournalStorageViewModel>();

        public EmployeeMainViewModel EmployeeMainView => ServiceLocator.Current.GetInstance<EmployeeMainViewModel>();
        public EmployeeBookStorageViewModel EmployeeBookStorage => ServiceLocator.Current.GetInstance<EmployeeBookStorageViewModel>();
        public EmployeeJournalStorageViewModel EmployeeJournalStorage => ServiceLocator.Current.GetInstance<EmployeeJournalStorageViewModel>();

        public CustomerMainViewModel CustomerMainView => ServiceLocator.Current.GetInstance<CustomerMainViewModel>();
        public PurchaseBooksViewModel PurchaseBooks => ServiceLocator.Current.GetInstance<PurchaseBooksViewModel>();
        public PurchaseJournalsViewModel PurchaseJournals => ServiceLocator.Current.GetInstance<PurchaseJournalsViewModel>();
        public ShoppingCartViewModel ShoppingCart => ServiceLocator.Current.GetInstance<ShoppingCartViewModel>();
    }
}