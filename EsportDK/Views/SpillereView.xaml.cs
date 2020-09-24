using EsportDK.Models;
using EsportDK.Views.Pages;
using System.Linq;
using System.Windows.Controls;

namespace EsportDK.Views
{
    /// <summary>
    /// Interaction logic for SpillereView.xaml
    /// </summary>
    public partial class SpillereView
    {

        EsportDKDBEntities _db = new EsportDKDBEntities();
        public static DataGrid datagrid;

        public SpillereView()
        {
            InitializeComponent();

            Load();
        }

        /// <summary>
        /// Upon load Spiller 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        private void Load()
        {
            // Creates List holding data from table in database 
            var data = _db.Spilleres.ToList();

            // If table populated...
            if (data.Count > 0)
            {
                // assign data to data grid
                spillerDataGrid.ItemsSource = data;
                // Sets new instance of datagrid
                datagrid = spillerDataGrid;
            }

        }

        /// <summary>
        /// Opens up edit window  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redigerSpillerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int Id = (spillerDataGrid.SelectedItem as Spillere).ID;
            spillerPageView spillerPage = new spillerPageView(Id);
            spillerPage.ShowDialog();
        }
    }
}
