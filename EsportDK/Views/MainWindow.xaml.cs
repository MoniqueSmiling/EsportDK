using EsportDK.ViewModels;
using System.Windows;

namespace EsportDK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }


        #region Menu Clicks

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spillereMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SpillereViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void turneringerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new TurneringerViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ansatteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AnsatteViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sponsorerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SponsorerViewModel();
        }

        #endregion
    }
}
