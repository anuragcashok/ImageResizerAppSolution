using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageResizerApp.Pages;
using ImageResizerApp.ViewModels;

namespace ImageResizerApp
{
    public static class ImageConfig
    {
        public static AddOrEditWindow addOrEditWindow{ get; set; }
        public static AddOrEditViewModel addOrEditViewModel{ get; set; }
        public static MainViewModel mainViewModel{ get; set; }

        static ImageConfig()
        {
            addOrEditWindow = new AddOrEditWindow(",");
            mainViewModel = new MainViewModel();
            addOrEditViewModel = new AddOrEditViewModel();
        }
    }
}
