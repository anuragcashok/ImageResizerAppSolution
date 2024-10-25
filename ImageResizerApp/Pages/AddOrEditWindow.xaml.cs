using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ImageResizerApp.ViewModels;

namespace ImageResizerApp.Pages
{
    /// <summary>
    /// Interaction logic for AddOrEditWindow.xaml
    /// </summary>
    public partial class AddOrEditWindow : Window
    {
       private AddOrEditViewModel viewModel;
        public AddOrEditWindow(string mode, string itemName = "")
        {
            InitializeComponent();
            /*viewModel = new AddOrEditViewModel
            {
                Mode = mode,
                ItemName = itemName
            };*/
            DataContext = ImageConfig.mainViewModel;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //e.Cancel = true;
            this.Hide();
            
        }
    }
}
