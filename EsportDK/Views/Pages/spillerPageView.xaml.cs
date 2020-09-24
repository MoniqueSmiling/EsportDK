using EsportDK.Models;
using System.Windows;

namespace EsportDK.Views.Pages
{
    /// <summary>
    /// Interaction logic for spillerPageView.xaml
    /// </summary>
    public partial class spillerPageView : Window
    {
        EsportDKDBEntities _db = new EsportDKDBEntities();
        int ID;

        public spillerPageView(int id)
        {
            InitializeComponent();
            ID = id;
        }
    }
}
