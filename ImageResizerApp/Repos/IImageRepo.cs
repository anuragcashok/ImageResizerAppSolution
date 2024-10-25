using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ImageResizerApp.Models;

namespace ImageResizerApp.Repos
{
    /// <summary>
    /// Represents a repository for managing images.
    /// </summary>
    public interface IImageRepo
    {
        /// <summary>
        /// Creates a new image.
        /// </summary>
        /// <param name="image">The image to add.</param>
        void Create(ImageModel image);
        
        /// <summary>
        /// Retrieves all images.
        /// </summary>
        /// <returns>A collection of all images.</returns>
        ObservableCollection<ImageModel> ReadAll();

        /// <summary>
        /// Updates an existing image.
        /// </summary>
        /// <param name="image">The image to edit.</param>
        void Update(ImageModel image);

        /// <summary>
        /// Deletes an image.
        /// </summary>
        /// <param name="image">The image to delete.</param>
        void Delete(ImageModel image);
        void Save();
        void Browse();
    }
}
