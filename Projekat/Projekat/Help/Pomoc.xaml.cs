using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat.Help
{
    /// <summary>
    /// Interaction logic for Pomoc.xaml
    /// </summary>
    public partial class Pomoc : Window
    {
        public Pomoc()
        {
            InitializeComponent();

            web.Navigate("C:/Users/Lemur/GIT/HCI/Projekat/Projekat/Help/index.htm");
        }

        #region BACK

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((web != null) && (web.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            web.GoBack();
        }

        #endregion BACK

        #region FORWARD
        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((web != null) && (web.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            web.GoForward();
        }
        #endregion FORWARD


    }
}
