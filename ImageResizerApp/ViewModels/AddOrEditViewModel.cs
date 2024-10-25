using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ImageResizerApp.Commands;
using ImageResizerApp.Models;
using Microsoft.Win32;

namespace ImageResizerApp.ViewModels
{
    public class AddOrEditViewModel : ViewModelBase
    {

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
        /*private string itemName;

        public string ItemName
        {
            get { return itemName; }
            set 
            {
                itemName = value;
                OnPropertyChanged(nameof(ItemName));
            }
        }
        private string mode;

        public string Mode
        {
            get { return mode; }
            set 
            {
                mode = value;
                OnPropertyChanged(nameof(Mode));
            }
        }*/

        private BitmapImage image;

        public BitmapImage Image
        {
            get { return image; }
            set 
            { 
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }


        public ICommand SaveCommand { get; }
        public ICommand BrowseCommand { get; }
        

        public AddOrEditViewModel()
        {
            BrowseCommand = new RelayCommand(Browse);
            SaveCommand = new RelayCommand(Save);
        }

        private void Browse()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Image = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
        private void Save()
        {
            if (NewImage == null)
            {
                MessageBox.Show("oombe");
            }
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*",
                    Title = "Save an Image"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    // Get the file path
                    string filePath = saveFileDialog.FileName;

                    // Save the image
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        BitmapEncoder encoder = new PngBitmapEncoder(); // You can choose the encoder based on the file type
                        encoder.Frames.Add(BitmapFrame.Create(Image));
                        encoder.Save(stream);
                    }
                }
            
        }
    }
}
