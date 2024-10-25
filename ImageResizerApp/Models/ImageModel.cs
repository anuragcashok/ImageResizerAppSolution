using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using ImageResizerApp.ViewModels;

namespace ImageResizerApp.Models
{
    /// <summary>
    /// Represents 
    /// </summary>
    public class ImageModel : ViewModelBase
    {
        internal BitmapSource Source;

        /// <summary>
        /// Gets or sets the image name.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets the image height.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the image width.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the image rotation.
        /// </summary>
        public double Rotation { get; set; }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        public string Path { get; set; }

        //public BitmapImage ImageSource
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Path))
        //        {
        //            return new BitmapImage(new Uri(Path));
        //        }
        //        return null;
        //    }
        //}

    }
}
