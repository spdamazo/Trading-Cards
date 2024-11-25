using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Stephanie_Maru_A3
{
    public partial class Form2 : Form
    {
        private PlayerManager playerManager;  // Manager for player data operations
        private Action refreshPlayerList;    // Delegate to refresh player list in the main form
        private Player currentPlayer;        // The current player being edited or added (if null, a new player is created)

        // Constructor: Initializes the form with player data or prepares for adding a new player
        public Form2(PlayerManager manager, Action refreshList, Player selectedPlayer = null)
        {
            InitializeComponent();
            playerManager = manager; // Assign the player manager for data handling
            refreshPlayerList = refreshList; // Delegate to refresh the list after saving changes

            // Initialize currentPlayer based on whether a player is selected
            if (selectedPlayer != null)
            {
                currentPlayer = selectedPlayer; // Use the selected player to populate fields
                InitializeFormFields(); // Initialize the form fields with existing player data
            }
            else
            {
                currentPlayer = new Player(); // Create a new player if none is selected
            }

            InitializeTeamDropdown(); // Set up the team dropdown with available teams
        }

        // Initialize the team selection dropdown with predefined teams
        private void InitializeTeamDropdown()
        {
            // Adding team names to the ComboBox for selection
            comboBoxTeam.Items.AddRange(new string[] {
                "Lakers", "Suns", "Bucks", "Warriors", "76ers",
                "Mavericks", "Nuggets", "Clippers", "Heat"
            });
            comboBoxTeam.SelectedIndex = 0; // Set the default team as the first item in the list
        }

        // Method to initialize form fields with selected player's data
        private void InitializeFormFields()
        {
            // Populate the form with data from the current player
            textBoxName.Text = currentPlayer.Name;
            comboBoxTeam.SelectedItem = currentPlayer.Team;
            textBoxPhotoPath.Text = currentPlayer.PhotoPath;

            // Set statistical values
            textBoxPoints.Text = currentPlayer.Points.ToString();
            textBoxAssists.Text = currentPlayer.Assists.ToString();
            textBoxRebounds.Text = currentPlayer.Rebounds.ToString();
            textBoxSteals.Text = currentPlayer.Steals.ToString();
            textBoxBlocks.Text = currentPlayer.Blocks.ToString();
            textBoxTurnovers.Text = currentPlayer.Turnovers.ToString();
            textBoxFouls.Text = currentPlayer.Fouls.ToString();
            textBoxGamesPlayed.Text = currentPlayer.GamesPlayed.ToString();
        }

        // Handle photo upload button click: Open a file dialog for selecting a photo
        private void buttonUploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a Photo",  // Title of the dialog window
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif" // Image file filters
            };

            // Show dialog and check if the user selects a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPhotoPath.Text = openFileDialog.FileName; // Set the selected file path
            }
        }

        // Handle save button click: Validate input and save player data
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Validate required fields like name and statistics
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please enter the player's name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate all statistics fields for positive values
            if (!IsPositiveNumber(textBoxPoints.Text, "Points") ||
                !IsPositiveNumber(textBoxAssists.Text, "Assists") ||
                !IsPositiveNumber(textBoxRebounds.Text, "Rebounds") ||
                !IsPositiveNumber(textBoxSteals.Text, "Steals") ||
                !IsPositiveNumber(textBoxBlocks.Text, "Blocks") ||
                !IsPositiveNumber(textBoxTurnovers.Text, "Turnovers") ||
                !IsPositiveNumber(textBoxFouls.Text, "Fouls") ||
                !IsPositiveNumber(textBoxGamesPlayed.Text, "Games Played"))
            {
                return; // Exit early if validation fails
            }

            // Set the player's details
            currentPlayer.Name = textBoxName.Text;
            currentPlayer.Team = comboBoxTeam.SelectedItem.ToString();
            currentPlayer.PhotoPath = textBoxPhotoPath.Text;

            // Set the logo path based on the selected team
            string logoFileName = $@"Logos\{comboBoxTeam.SelectedItem.ToString().ToLower()}_logo.png";
            currentPlayer.TeamLogoPath = logoFileName;

            // Set statistical data
            currentPlayer.Points = int.Parse(textBoxPoints.Text);
            currentPlayer.Assists = int.Parse(textBoxAssists.Text);
            currentPlayer.Rebounds = int.Parse(textBoxRebounds.Text);
            currentPlayer.Steals = int.Parse(textBoxSteals.Text);
            currentPlayer.Blocks = int.Parse(textBoxBlocks.Text);
            currentPlayer.Turnovers = int.Parse(textBoxTurnovers.Text);
            currentPlayer.Fouls = int.Parse(textBoxFouls.Text);
            currentPlayer.GamesPlayed = int.Parse(textBoxGamesPlayed.Text);

            try
            {
                // Check if the player already exists (update or add accordingly)
                if (playerManager.GetPlayerByName(currentPlayer.Name) != null)
                {
                    playerManager.UpdatePlayer(currentPlayer); // Update existing player
                }
                else
                {
                    playerManager.AddPlayer(currentPlayer); // Add new player
                }
            }
            catch (ArgumentException ex)
            {
                // Handle any errors (e.g., player name conflict)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Refresh the player list in the main form
            refreshPlayerList?.Invoke();

            // Show success message and close the form
            MessageBox.Show($"Player {currentPlayer.Name} has been saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // Helper method to validate that input is a positive number
        private bool IsPositiveNumber(string input, string fieldName)
        {
            if (!int.TryParse(input, out int value) || value < 0)
            {
                // Show an error message if the value is not a positive number
                MessageBox.Show($"{fieldName} must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Handle cancel button click: Close the form without saving
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Close without saving any changes
        }
    }
}
