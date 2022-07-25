using BookStore.Models.Enums;
using BookStore.Server;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel.ManagerViewModel
{
    public class AddJournalsViewModel : ViewModelBase
    {
        #region PROPERTIES
        public string JournalTitle { get; set; }
        public string EditorName { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.Today;
        public int IssueNumber { get; set; }
        public decimal JournalPrice { get; set; }
        public ObservableCollection<JournalGenre> JournalGenres { get; set; }
        public ObservableCollection<JournalFrequency> JournalFrequencies { get; set; }
        public ListBox CustomListBox { get; set; }
        public List<JournalGenre> SelectedGenres { get; set; }
        public JournalFrequency Frequency { get; set; }
        public RelayCommand AddJournalCommand { get; set; }
        ProductsService productsService;
        #endregion
        public AddJournalsViewModel()
        {
            productsService = new ProductsService();
            JournalGenres = new ObservableCollection<JournalGenre>(Enum.GetValues(typeof(JournalGenre)).Cast<JournalGenre>());
            JournalFrequencies = new ObservableCollection<JournalFrequency>(Enum.GetValues(typeof(JournalFrequency)).Cast<JournalFrequency>());
            SelectedGenres = new List<JournalGenre>();
            AddJournalCommand = new RelayCommand(AddJournal);
            InitListBox();
        }
        private void AddJournal()
        {
            //Check input
            if (JournalTitle == default || EditorName == default || JournalPrice == default ||
                IssueNumber == default || Frequency==default || SelectedGenres.Count == 0)
            {
                MessageBox.Show("Some Fields Arent Filled", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            productsService.AddJournal(JournalTitle, EditorName, IssueNumber,
                PublicationDate, JournalPrice, Frequency, JournalGenres.ToArray());
        }
        //NOTE: in order to access SelectedItems property I need to define a listview via code behind.
        private void InitListBox()
        {
            CustomListBox = new ListBox();
            CustomListBox.ItemsSource = JournalGenres;
            CustomListBox.SelectionMode = SelectionMode.Multiple;
            CustomListBox.SelectionChanged += CustomListBox_SelectionChanged;
        }
        private void CustomListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedGenres.Clear();
            foreach (var item in CustomListBox.SelectedItems)
            {
                SelectedGenres.Add((JournalGenre)item);
            }
        }
    }
}
