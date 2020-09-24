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
        // 
        EsportDKDBEntities _db = new EsportDKDBEntities();

        public static DataGrid datagrid;

        // Variable for holding Id
        int Id;

        public SpillereView()
        {
            InitializeComponent();
            Load();
        }

        /// <summary>
        /// Populates datagrid with data upon load   
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
        /// Makes it possible to update entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redigerSpillerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Id = (spillerDataGrid.SelectedItem as Spillere).ID;

            Spillere updateSpiller = (from spiller in _db.Spilleres
                                      where spiller.ID == Id
                                      select spiller).Single();


            registrerButton.Content = "Update";

            // Fills TextBoxes with data from Spillere.ID
            fornavnSpillerText.Text = updateSpiller.Fornavn;
            efternavnSpillerText.Text = updateSpiller.Efternavn;
            SummonerSpillerText.Text = updateSpiller.SummonerName;
            telefonSpillerText.Text = updateSpiller.Telefon;
            spillerTurneringstypeComboBox.Text = updateSpiller.Rang;
            TurneringsTypeCombobox.Text = updateSpiller.TurneringsType;

        }

        /// <summary>
        /// Registering new and updating Spiller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registrerSpillerButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            var buttonContent = (string)registrerButton.Content;

            // If buttons content is...
            if (buttonContent == "Update")
            {
                // Finds existing Spiller in Database...
                Spillere updateSpiller = (from spiller in _db.Spilleres
                                          where spiller.ID == Id
                                          select spiller).Single();

                // Reassigns values to existing instance of Spiller
                updateSpiller.Fornavn = fornavnSpillerText.Text;
                updateSpiller.Efternavn = efternavnSpillerText.Text;
                updateSpiller.SummonerName = SummonerSpillerText.Text;
                updateSpiller.Telefon = telefonSpillerText.Text;
                updateSpiller.Rang = spillerTurneringstypeComboBox.Text;
                updateSpiller.TurneringsType = TurneringsTypeCombobox.Text;
            }
            // Otherwise...
            else
            {
                // Create a new Spiller and populate it with data from the form
                Spillere nySpiller = new Spillere()
                {
                    Fornavn = fornavnSpillerText.Text.Trim(),
                    Efternavn = efternavnSpillerText.Text.Trim(),
                    SummonerName = SummonerSpillerText.Text.Trim(),
                    Telefon = telefonSpillerText.Text.Trim(),
                    Rang = spillerTurneringstypeComboBox.Text,
                    TurneringsType = TurneringsTypeCombobox.Text
                };

                // Adds new Spiller to database
                _db.Spilleres.Add(nySpiller);
            }

            // Saves changes to satabase 
            _db.SaveChanges();
            datagrid.ItemsSource = _db.Spilleres.ToList();

            // Changes buttons content back
            if (buttonContent == "Update")
                buttonContent = "Registrer";
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
    }
}
