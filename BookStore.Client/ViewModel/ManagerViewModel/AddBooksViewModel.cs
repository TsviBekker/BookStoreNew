using BookStore.Models;
using BookStore.Server;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel
{
    //NOTE: this viewmodel is also used to update a book
    public class AddBooksViewModel : ViewModelBase
    {
        #region PROPERTIES
        private ListBox customListBox;
        public ListBox CustomListBox { get => customListBox; set => Set(ref customListBox, value); }
        public List<BookGenre> SelectedGenres { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string BookSummary { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.Today;
        public int BookEdition { get; set; }
        public decimal BookPrice { get; set; }
        public ObservableCollection<BookGenre> BookGenres { get => bookGenres; set => bookGenres = value; }
        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand SelectImageCommand { get; set; }
        private string imagePath;
        public string ImagePath { get => imagePath; set => Set(ref imagePath, value); }
        ProductsService productManager;
        private ObservableCollection<BookGenre> bookGenres;
        bool update;
        public Book BookToUpdate { get; private set; }
        #endregion
        public AddBooksViewModel()
        {
            productManager = new ProductsService();
            BookGenres = new ObservableCollection<BookGenre>(Enum.GetValues(typeof(BookGenre)).Cast<BookGenre>());
            AddBookCommand = new RelayCommand(AddBook);
            SelectImageCommand = new RelayCommand(SelectImage);
            SelectedGenres = new List<BookGenre>();
            MessengerInstance.Register<Book>(this, "updatebook", UpdateBook);
            MessengerInstance.Register<bool>(this, "reset", ResetProperties);
            InitListBox();
            ResetProperties(true);
        }

        private void ResetProperties(bool b)
        {
            if (!b) return;
            BookAuthor = default;
            BookEdition = default;
            BookTitle = default;
            PublicationDate = DateTime.Today;
            BookPrice = default;
            BookSummary = default;
            ImagePath = default;
        }

        //Selecting an image is done via OpenFileDialog
        private void SelectImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpeg;*.gif;*.jpg*.jfif;";
            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = openFileDialog.FileName;
            }
        }
        //NOTE: in order to access SelectedItems property I need to define a listview via code behind.
        private void InitListBox()
        {
            CustomListBox = new ListBox();
            CustomListBox.ItemsSource = BookGenres;
            CustomListBox.SelectionMode = SelectionMode.Multiple;
            CustomListBox.SelectionChanged += CustomListBox_SelectionChanged;
        } 
        //This method is called by the MI. It sets the UI properties according to the properties of the bookToUpdate
        private void UpdateBook(Book bookToUpdate)
        {
            BookToUpdate = bookToUpdate;
            update = true;
            BookTitle = bookToUpdate.Title;
            BookAuthor = bookToUpdate.AuthorName;
            PublicationDate = bookToUpdate.PublicationDate;
            BookPrice = bookToUpdate.BasePrice;
            BookEdition = bookToUpdate.Edition;
            BookSummary = bookToUpdate.Summary;
            SelectedGenres = bookToUpdate.Genres.ToList();
            imagePath = bookToUpdate.ProductImageSource;
        } 
        private void CustomListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedGenres.Clear();
            foreach (var item in CustomListBox.SelectedItems)
            {
                SelectedGenres.Add((BookGenre)item);
            }
        }
        private void AddBook()
        {
            if (BookTitle == default || BookAuthor == default || BookPrice == default || SelectedGenres.Count == 0)
            {
                MessageBox.Show("Some Fields Arent Filled", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!update) //if this viewmodel is called in order to ADD the book
                productManager.AddBook(BookTitle, BookAuthor, PublicationDate, BookPrice,
                    BookEdition, BookSummary, ImagePath, SelectedGenres.ToArray());
            else if (update) //if this viewmodel is called in order to UPDATE the book
            {
                UpdateBookProperties();
                productManager.UpdateBook(BookToUpdate);
                update = false;
                MessengerInstance.Send<bool>(true, "updated"); //this will be registered by the BookStorageViewModel
            }
        }
        //This method updates the book with the new/old properties
        private void UpdateBookProperties()
        {
            BookToUpdate.Title = BookTitle;
            BookToUpdate.AuthorName = BookAuthor;
            BookToUpdate.PublicationDate = PublicationDate;
            BookToUpdate.BasePrice = BookPrice;
            BookToUpdate.Edition = BookEdition;
            BookToUpdate.Summary = BookSummary;
            BookToUpdate.Genres = SelectedGenres;
            BookToUpdate.ProductImageSource = ImagePath;
        }
    }
}
