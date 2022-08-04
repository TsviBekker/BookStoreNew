
using BookStore.Service.Context;
using BookStore.Service.Context.Models;
using BookStore.Service.Context.Models.Enums;
using BookStore.Service.Repositories.BookRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookStore.Client.ViewModel.ManagerViewModel
{
    //NOTE: this viewmodel is also used to update a book
    public class AddBooksViewModel : ViewModelBase
    {
        private ListBox customListBox;
        public ListBox CustomListBox { get => customListBox; set => Set(ref customListBox, value); }

        //private ObservableCollection<BookGenre> bookGenres;
        //public ObservableCollection<BookGenre> BookGenres { get => bookGenres; set => bookGenres = value; }

        private string imagePath;
        public string ImagePath { get => imagePath; set => Set(ref imagePath, value); }

        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string BookSummary { get; set; }
        public decimal BookPrice { get; set; }
        public int BookEdition { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.Today;
        public BookGenre SelectedGenre { get; set; }

        public RelayCommand AddBookCommand { get; set; }
        public RelayCommand SelectImageCommand { get; set; }

        private bool update;

        public Book BookToUpdate { get; set; }

        private readonly IBookRepository bookRepository;

        //Ctor
        public AddBooksViewModel(IBookRepository bookRepository)
        {
            MessengerInstance.Register<Book>(this, "updatebook", UpdateBookUI);
            MessengerInstance.Register<bool>(this, "reset", b => ResetProperties());

            this.bookRepository = bookRepository;

            AddBookCommand = new RelayCommand(HandleBook);
            SelectImageCommand = new RelayCommand(SelectImage);


            InitListBox();
        }

        private async void HandleBook()
        {
            if (BookTitle == default || BookAuthor == default ||
                BookPrice == default || SelectedGenre == default)
            {
                MessageBox.Show("Some Fields Arent Filled", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (update)
            {
                await UpdateBookAsync();
                MessageBox.Show("Book Updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                await AddBookAsync();
                MessageBox.Show("Book Added", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            //await bookRepository.Complete();
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

        private void InitListBox()
        {
            CustomListBox = new ListBox()
            {
                ItemsSource = new ObservableCollection<BookGenre>(Enum.GetValues(typeof(BookGenre)).Cast<BookGenre>()),
                SelectionMode = SelectionMode.Single
                //SelectionMode = SelectionMode.Multiple

            };
            CustomListBox.SelectionChanged += (s, e) => CustomListBox_SelectionChanged();
        }

        //This method is called by the MI. It sets the UI properties according to the properties of the bookToUpdate
        private void UpdateBookUI(Book book)
        {
            BookToUpdate = book;
            update = true;

            BookTitle = BookToUpdate.Title;
            BookAuthor = BookToUpdate.AuthorName;
            PublicationDate = BookToUpdate.PublicationDate;
            BookPrice = BookToUpdate.BasePrice;
            BookEdition = BookToUpdate.Edition;
            BookSummary = BookToUpdate.Summary;
            SelectedGenre = BookToUpdate.Genre;
            imagePath = BookToUpdate.ProductImageSource;
        }

        private void CustomListBox_SelectionChanged()
        {
            SelectedGenre = (BookGenre)CustomListBox.SelectedItem;
            //SelectedGenre.Clear();
            //foreach (var item in CustomListBox.SelectedItems)
            //{
            //    SelectedGenre.Add((BookGenre)item);
            //}
        }

        private async Task UpdateBookAsync()
        {
            UpdateProperties();
            await bookRepository.Update(BookToUpdate, BookToUpdate.Id);
            update = false;
            MessengerInstance.Send(true, "updated"); //this will be registered by the BookStorageViewModel
        }

        private async Task AddBookAsync()
        {
            var book = new Book()
            {
                Title = BookTitle,
                AuthorName = BookAuthor,
                BasePrice = BookPrice,
                Edition = BookEdition,
                Genre = SelectedGenre,
                ProductImageSource = imagePath,
                PublicationDate = PublicationDate,
                Summary = BookSummary,
            };

            await bookRepository.Add(book);

            ResetProperties();
        }

        //This method updates the book with the new/old properties
        private void UpdateProperties()
        {
            BookToUpdate.Title = BookTitle;
            BookToUpdate.AuthorName = BookAuthor;
            BookToUpdate.PublicationDate = PublicationDate;
            BookToUpdate.BasePrice = BookPrice;
            BookToUpdate.Edition = BookEdition;
            BookToUpdate.Summary = BookSummary;
            BookToUpdate.Genre = SelectedGenre;
            BookToUpdate.ProductImageSource = ImagePath;
        }

        private void ResetProperties()
        {
            BookAuthor = default;
            BookEdition = default;
            BookTitle = default;
            PublicationDate = DateTime.Today;
            BookPrice = default;
            BookSummary = default;
            ImagePath = default;
        }
    }
}
