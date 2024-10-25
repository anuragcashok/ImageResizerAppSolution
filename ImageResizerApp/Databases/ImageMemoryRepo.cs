using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageResizerApp.Models;
using ImageResizerApp.Repos;

namespace ImageResizerApp.Databases
{
    /// <summary>
    /// Represents a repository for managing images in memory.
    /// </summary>
    public class ImageMemoryRepo : IImageRepo
    {
        private ObservableCollection<ImageModel> images;

        /// <summary>
        /// Gets the instance of the ImageMemoryRepo class.
        /// </summary>
        private static ImageMemoryRepo instance;

        /// <summary>
        /// Initializes a new instance of ImageMemoryRepo class.
        /// </summary>
        public ImageMemoryRepo()
        {
            images = new ObservableCollection<ImageModel>();
            InitializeImages();
        }

        /// <summary>
        /// Initializes the images collection with default values.
        /// </summary>
        private void InitializeImages()
        {
            //throw new NotImplementedException();
            images.Add(new ImageModel
            {
                Name = "Image1",
                Width = 100,
                Height = 80,
                Rotation = 90,
                Path = "C:\\Users\\2021479\\Downloads\\duck.jpg",
            });
        }

        public static ImageMemoryRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImageMemoryRepo();
                }
                return instance;
            }
        }

        public void Browse()
        {
            throw new NotImplementedException();
        }

        public void Create(ImageModel image)
        {
            //throw new NotImplementedException();
            images.Add(image);
        }

        public void Delete(ImageModel image)
        {
            //throw new NotImplementedException();
            var existingImage = images.FirstOrDefault(images => images.Name == image.Name);
            images.Remove(existingImage);
        }

        public ObservableCollection<ImageModel> ReadAll()
        {
            //throw new NotImplementedException();
            return images;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ImageModel image)
        {
            //throw new NotImplementedException();
            var existingImage = images.FirstOrDefault(images => images.Name == image.Name);
            if (existingImage != null)
            {
                existingImage.Width = image.Width;
                existingImage.Height = image.Height;
                existingImage.Name = image.Name;
                existingImage.Rotation = image.Rotation;
            }
        }
    }
}
