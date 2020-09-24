using EsportDK.Models;
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

            Spillere updateSpiller = (from spiller in _db.Spilleres
                                      where spiller.ID == Id
                                      select spiller).Single();

            fornavnSpillerText.Text = updateSpiller.Fornavn;
            efternavnSpillerText.Text = updateSpiller.Efternavn;
            SummonerSpillerText.Text = updateSpiller.SummonerName;
            telefonSpillerText.Text = updateSpiller.Telefon;
            spillerTurneringstypeComboBox.Text = updateSpiller.Rang;
            TurneringsTypeCombobox.Text = updateSpiller.TurneringsType;

        }

        /// <summary>
        /// Clears form of data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelSpillerinput_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Clear data
            fornavnSpillerText.Text = efternavnSpillerText.Text = SummonerSpillerText.Text = telefonSpillerText.Text = spillerTurneringstypeComboBox.Text = TurneringsTypeCombobox.Text = "";
        }

        /// <summary>
        /// Registering new Spiller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registretSpillerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            try
            {
                Spillere nySpiller = new Spillere()
                {
                    Fornavn = fornavnSpillerText.Text.Trim(),
                    Efternavn = efternavnSpillerText.Text.Trim(),
                    SummonerName = SummonerSpillerText.Text.Trim(),
                    Telefon = telefonSpillerText.Text.Trim(),
                    Rang = spillerTurneringstypeComboBox.Text,
                    TurneringsType = TurneringsTypeCombobox.Text
                };

                _db.Spilleres.Add(nySpiller);
                _db.SaveChanges();
                datagrid.ItemsSource = _db.Spilleres.ToList();
            }
            catch (System.Exception)
            {

                throw;
            }



        }
    }
}
