using EsportDK.Models;
using System.Linq;
using System.Windows.Controls;

namespace EsportDK.Views
{
    /// <summary>
    /// Interaction logic for SpillereView.xaml
    /// </summary>
    public partial class SponsorerView
    {
        // 
        EsportDKDBEntities _db = new EsportDKDBEntities();

        public static DataGrid datagrid;

        // Variable for holding Id
        int Id;

        public SponsorerView()
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
            var data = _db.Sponsorers.ToList();

            // If table populated...
            if (data.Count > 0)
            {
                // assign data to data grid
                sponsorDataGrid.ItemsSource = data;
                // Sets new instance of datagrid
                datagrid = sponsorDataGrid;
            }

        }

        /// <summary>
        /// Makes it possible to update entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void redigerSponsorButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Id = (sponsorDataGrid.SelectedItem as Sponsorer).ID;

            Sponsorer updateSponsor = (from sponsor in _db.Sponsorers
                                       where sponsor.ID == Id
                                       select sponsor).Single();


            registrerButton.Content = "Update";

            // Fills TextBoxes with data from Spillere.ID
            firmanavnText.Text = updateSponsor.Firmanavn;
            brancheComboBox.Text = updateSponsor.Branche;
            spillerIDText.Text = updateSponsor.SpillerID.ToString();
            udgiftText.Text = updateSponsor.Udgift.ToString();
        }

        /// <summary>
        /// Registering new and updating Spiller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registrerSponsorButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            var buttonContent = (string)registrerButton.Content;

            // If buttons content is...
            if (buttonContent == "Update")
            {
                // Finds existing Spiller in Database...
                Sponsorer updateSponsor = (from sponsor in _db.Sponsorers
                                           where sponsor.ID == Id
                                           select sponsor).Single();

                // Reassigns values to existing instance of Spiller
                updateSponsor.Firmanavn = firmanavnText.Text;
                updateSponsor.Branche = brancheComboBox.Text;
                updateSponsor.SpillerID = int.Parse(spillerIDText.Text);
                updateSponsor.Udgift = int.Parse(udgiftText.Text);
            }
            // Otherwise...
            else
            {
                // Create a new Spiller and populate it with data from the form
                Sponsorer nySponsor = new Sponsorer()
                {
                    Firmanavn = firmanavnText.Text,
                    Branche = brancheComboBox.Text,
                    SpillerID = int.Parse(spillerIDText.Text),
                    Udgift = int.Parse(udgiftText.Text)
                };

                //// Adds new Spiller to database
                _db.Sponsorers.Add(nySponsor);
            }

            // Saves changes to satabase 
            _db.SaveChanges();
            datagrid.ItemsSource = _db.Sponsorers.ToList();

            // Changes buttons content back
            if (buttonContent == "Update")
                buttonContent = "Registrer";
        }

        /// <summary>
        /// Clears form of data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelSponsorinput_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            firmanavnText.Text = brancheComboBox.Text = spillerIDText.Text = udgiftText.Text = "";



            var buttonContent = (string)registrerButton.Content;

            // Changes buttons content back
            if (buttonContent == "Update")
                buttonContent = "Registrer";
        }
    }
}
