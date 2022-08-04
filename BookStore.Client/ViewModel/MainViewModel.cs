using BookStore.Client.View;
using GalaSoft.MvvmLight;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private UserControl currentContent;
        public UserControl CurrentContent { get => currentContent; set => Set(ref currentContent, value); }

        public MainViewModel()
        {
            CurrentContent = new PrimaryView();
            MessengerInstance.Register<UserControl>(this, newView => CurrentContent = newView);
        }
    }
}