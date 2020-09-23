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

        private void spillereMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SpillereViewModel();
        }

        private void turneringerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new TurneringerViewModel();
        }

        private void ansatteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AnsatteViewModel();
        }
        private void sponsorerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new SponsorerViewModel();
        }
    }
}
