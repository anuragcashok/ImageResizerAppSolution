using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ImageResizerApp.Commands;
using ImageResizerApp.Databases;
using ImageResizerApp.Models;
using ImageResizerApp.Repos;
using Microsoft.Win32;

namespace ImageResizerApp.ViewModels
{
    /// <summary>
    /// Represents a view model for managing images
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
		public ObservableCollection<ImageModel> Images { get; set; }
        public bool IsImageSelected
        {
            get
            {
                return SelectedImage != null;
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private ImageModel newImage;

        /// <summary>
        /// Gets or sets the new image.
        /// </summary>
        public ImageModel NewImage
        {
            get { return newImage; }
            set 
            { 
                newImage = value; 
                OnPropertyChanged(nameof(NewImage)); 
            }
        }


        private ImageModel selectedImage;

        /// <summary>
        /// Gets or sets the selected image.
        /// </summary>
		public ImageModel SelectedImage
		{
			get { return selectedImage; }
			set 
            { 
                selectedImage = value; 
                OnPropertyChanged(nameof(SelectedImage)); 
            }
		}
       




    /// <summary>
    /// Gets the images repository.
    /// </summary>
    private IImageRepo repo = ImageMemoryRepo.Instance;


        /// <summary>
        /// Gets the collection of images.
        /// </summary>
        public ObservableCollection<ImageModel> ImageModels
        {
            get { return repo.ReadAll(); }
        }



        /// <summary>
        /// Gets the command for creating a new image.
        /// </summary>
        public ICommand AddCommand { get; }

        /// <summary>
        /// Gets the command for updating an existing image.
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Gets the command for deleting an existing image.
        /// </summary>
        public ICommand DeleteCommand { get; }
        public ICommand BrowseCommand { get;}
		public ICommand CancelCommand { get;}
		public ICommand SaveCommand { get; }
        //public ICommand ExitCommand { get; }
        public ICommand ExportCommand { get; }


        public MainViewModel()
        {
            Images = new ObservableCollection<ImageModel>();
            NewImage = new ImageModel
            {
                Name = "anu",
                Width = 200,
                Height = 200,
                Rotation = 180,
            };
            ImageModels.Add(NewImage);
            AddCommand = new RelayCommand(AddImage);
            EditCommand = new RelayCommand(EditImage);
            DeleteCommand = new RelayCommand(DeleteImage);
            SaveCommand = new RelayCommand(SaveImage);
            ExportCommand = new RelayCommand(ExportImage);
            
            
        }

		/// <summary>
        /// Adds a new image.
        /// </summary>
        public void AddImage()
		{
            Title = "Add Image";
            ImageModel newImage = new ImageModel
            {
                Name = NewImage.Name,
                Width = NewImage.Width,
                Height = NewImage.Height,
                Rotation = NewImage.Rotation,
                Path = NewImage.Path,
            };
            var result = MessageBox.Show(messageBoxText: "Are you sure to create?",
                        caption: "Confirm",
                        button: MessageBoxButton.YesNo,
                        icon: MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            repo.Create(newImage);
            result = MessageBox.Show(messageBoxText: "Created Successfully",
            caption: "Alert",
            button: MessageBoxButton.OK,
            icon: MessageBoxImage.Information);
            this.selectedImage = NewImage;		
        }

        /// <summary>
        /// Update seleted image properties.
        /// </summary>
        public void EditImage()
        {
            Title = "Edit Image";
            var res = MessageBox.Show(messageBoxText: "Are you sure to Update?",
                    caption: "Confirm",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Question);

            if (res != MessageBoxResult.Yes)
            {
                return;
            }
            if (this.SelectedImage!=null)
            {
                repo.Update(this.SelectedImage);
                this.SelectedImage = this.SelectedImage;
                var result = MessageBox.Show(messageBoxText: $"Image {SelectedImage.Name} is updated successfully",
                        caption: "Alert",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Information);
            }
            else
            {
                return;
            }
        }
        public void DeleteImage()
        {
            if (SelectedImage != null)
            {
                var res = MessageBox.Show(messageBoxText: "Are you sure to Delete?",
                    caption: "Confirm",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Question);
                if (res != MessageBoxResult.Yes)
                {
                    return;
                }
                repo.Delete(this.SelectedImage);
                this.SelectedImage = this.SelectedImage;
                var result = MessageBox.Show(messageBoxText: $"Image {SelectedImage.Name} is deleted successfully",
                        caption: "Alert",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Information);
            }
            else
            {
                var result = MessageBox.Show(messageBoxText: "Please select an account to delete.",
                   caption: "Alert",
                   button: MessageBoxButton.OK,
                   icon: MessageBoxImage.Information);
                return;
            }
        }
        public void ExportToExcel()
        {

        }
        
        public void SaveImage()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*",
                Title = "Save an Image"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                BitmapSource bitmapSource = (BitmapSource)SelectedImage.Source;

                // Save the image
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    BitmapEncoder encoder = new PngBitmapEncoder(); // You can choose the encoder based on the file type
                    encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                    encoder.Save(stream);
                }
            }
        }
        public void ExportImage()
        {

        }

        private bool CanExecuteImageCommands() => IsImageSelected;
    }
}
