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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ImageResizerApp.Pages;
using ImageResizerApp.ViewModels;
namespace ImageResizerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ImageConfig.mainViewModel;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            //
        }



        /*private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            ImageConfig.addOrEditWindow.Show();
            ImageConfig.addOrEditWindow.Title = "Add Image";
        }*/

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ImageListBox.SelectedIndex == -1)
            {
                var result = MessageBox.Show(messageBoxText: "Please select an image to edit",
                    caption: "Alert",
                    button: MessageBoxButton.OK,
                    icon: MessageBoxImage.Information);
                return;
            }
            ImageConfig.addOrEditWindow.Show();
            ImageConfig.addOrEditWindow.Title = "Edit Image";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ImageConfig.addOrEditWindow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
           Application.Current.Shutdown();
        }
    }
}
