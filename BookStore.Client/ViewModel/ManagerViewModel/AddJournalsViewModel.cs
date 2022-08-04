using BookStore.Service.Context.Models;
using BookStore.Service.Context.Models.Enums;
using BookStore.Service.Repositories.JournalRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel.ManagerViewModel
{
    public class AddJournalsViewModel : ViewModelBase
    {
        public ObservableCollection<JournalGenre> JournalGenres { get; set; }
        public ObservableCollection<JournalFrequency> JournalFrequencies { get; set; }
        public JournalGenre SelectedGenre { get; set; }

        public string JournalTitle { get; set; }
        public string EditorName { get; set; }
        public int IssueNumber { get; set; }
        public decimal JournalPrice { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.Today;
        public ListBox CustomListBox { get; set; }
        public JournalFrequency Frequency { get; set; }

        public RelayCommand AddJournalCommand { get; set; }

        private readonly IJournalRepository journalRepository;

        //Ctor
        public AddJournalsViewModel(IJournalRepository journalRepository)
        {
            this.journalRepository = journalRepository;

            JournalGenres = new ObservableCollection<JournalGenre>(Enum.GetValues(typeof(JournalGenre)).Cast<JournalGenre>());
            JournalFrequencies = new ObservableCollection<JournalFrequency>(Enum.GetValues(typeof(JournalFrequency)).Cast<JournalFrequency>());

            AddJournalCommand = new RelayCommand(AddJournalAsync);
            InitListBox();
        }
        private async void AddJournalAsync()
        {
            //Check input
            if (JournalTitle == default || EditorName == default || JournalPrice == default ||
                IssueNumber == default || Frequency == default || SelectedGenre == default)
            {
                MessageBox.Show("Some Fields Arent Filled", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var journal = new Journal()
            {
                BasePrice = JournalPrice,
                EditorName = EditorName,
                Genre = SelectedGenre,
                IssueNumber = IssueNumber,
                JournalFrequency = Frequency,
                Name = JournalTitle,
                PublicationDate = PublicationDate,
            };

            await journalRepository.Add(journal);
            //journalRepository.Complete();

            ResetProperties();
        }
        //NOTE: in order to access SelectedItems property I need to define a listview via code behind.
        private void InitListBox()
        {
            CustomListBox = new ListBox()
            {
                ItemsSource = JournalGenres,
                SelectionMode = SelectionMode.Single
                //SelectionMode = SelectionMode.Multiple
            };
            CustomListBox.SelectionChanged += (s, e) => CustomListBox_SelectionChanged();
        }

        private void CustomListBox_SelectionChanged()
        {
            SelectedGenre = (JournalGenre)CustomListBox.SelectedItem;
            //SelectedGenre.Clear();
            //foreach (var item in CustomListBox.SelectedItems)
            //{
            //    SelectedGenre.Add((JournalGenre)item);
            //}
        }

        private void ResetProperties()
        {
            JournalPrice = default;
            JournalTitle = default;
            EditorName = default;
            SelectedGenre = default;
            IssueNumber = default;
            Frequency = default;
            JournalTitle = default;
            PublicationDate = DateTime.Today;
        }
    }
}
