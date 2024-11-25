namespace Stephanie_Maru_A3
{
    public partial class Form1 : Form
    {
        private PlayerManager playerManager; // Manages the list of players
        private Bitmap teamLogoBitmap; // Holds the team logo for the selected player

        public Form1()
        {
            InitializeComponent();
            playerManager = new PlayerManager();

            InitializePlayerList();
            InitializeDataGridView();

            // Set the first player as the default selected player when the form loads
            SetDefaultPlayer();

            // Attach a custom paint event handler for the player photo area
            pictureBoxPhoto.Paint += PictureBoxPhoto_Paint;
        }

        // Initializes the ListBox for displaying player names
        private void InitializePlayerList()
        {
            listBoxPlayers.DataSource = playerManager.Players;
            listBoxPlayers.DisplayMember = "Name"; // Displays player names
            listBoxPlayers.SelectedIndexChanged += ListBoxPlayers_SelectedIndexChanged; // Event for selection change
        }

        // Handles the event when a player is selected in the ListBox
        private void ListBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlayers.SelectedItem is Player selectedPlayer)
            {
                DisplayCard(selectedPlayer); // Show player's card
                UpdateDataGridView(selectedPlayer); // Show player's stats in the DataGridView
                pictureBoxPhoto.Invalidate(); // Trigger photo area repaint
                LoadTeamLogo(selectedPlayer); // Load the team logo
            }
        }

        // Sets up the DataGridView for displaying player stats
        private void InitializeDataGridView()
        {
            dataGridView1.DataSource = playerManager.Players;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;

            // Set column headers and visibility
            CustomizeDataGridViewColumns();
        }

        // Updates the DataGridView with a specific player's stats
        private void UpdateDataGridView(Player player)
        {
            dataGridView1.DataSource = new List<Player> { player }; // Show only the selected player
        }

        // Displays the selected player's card
        private void DisplayCard(Player player)
        {
            pictureBoxPhoto.ImageLocation = player.PhotoPath; // Load player's photo
            pictureBoxPhoto.SizeMode = PictureBoxSizeMode.StretchImage; // Stretch photo to fit
            panelCard.BackColor = GetTeamColor(player.Team); // Set card background to team color

            LoadTeamLogo(player); // Load and set the team logo
            pictureBoxPhoto.Invalidate(); // Redraw the photo area
        }

        // Handles the Paint event to custom draw the player's photo and stats
        private void PictureBoxPhoto_Paint(object sender, PaintEventArgs e)
        {
            if (listBoxPlayers.SelectedItem is Player player)
            {
                DrawPlayerPhoto(e.Graphics, player); // Draw the player's photo
                DrawTextWithShadow(e.Graphics, player.Name, new Font("Arial", 16, FontStyle.Bold), Brushes.White, new PointF(10f, pictureBoxPhoto.Height - 50f)); // Draw player name
                DrawPlayerStats(e.Graphics, player); // Draw player stats
                DrawTeamLogo(e.Graphics); // Draw team logo
            }
        }



        // Draws text with a shadow effect for better readability
        private void DrawTextWithShadow(Graphics g, string text, Font font, Brush brush, PointF location)
        {
            const float shadowOffset = 2f;
            g.DrawString(text, font, Brushes.Black, location.X + shadowOffset, location.Y + shadowOffset); // Draw shadow
            g.DrawString(text, font, brush, location); // Draw actual text
        }



        // Loads the team logo for a player
        private void LoadTeamLogo(Player player)
        {
            if (File.Exists(player.TeamLogoPath))
            {
                teamLogoBitmap = new Bitmap(player.TeamLogoPath); // Load logo if exists
            }
            else
            {
                teamLogoBitmap = null; // Clear logo if not found
            }
        }

        // Draws the player's photo
        private void DrawPlayerPhoto(Graphics graphics, Player player)
        {
            if (File.Exists(player.PhotoPath))
            {
                using (var photoImage = Image.FromFile(player.PhotoPath))
                {
                    graphics.DrawImage(photoImage, new Rectangle(0, 0, pictureBoxPhoto.Width, pictureBoxPhoto.Height));
                }
            }
        }

        // Draws all player stats with conditional coloring
        private void DrawPlayerStats(Graphics graphics, Player player)
        {
            using (var font = new Font("Arial", 12, FontStyle.Bold))
            {
                float yOffset = 10f;
                const float lineSpacing = 30f;

                // List all stats to display
                DrawTextWithShadow(graphics, $"PTS: {player.Points}", font, GetStatBrush(player.Points), new PointF(10, yOffset));
                yOffset += lineSpacing;

                DrawTextWithShadow(graphics, $"AST: {player.Assists}", font, GetStatBrush(player.Assists, 5), new PointF(10, yOffset));
                yOffset += lineSpacing;

                DrawTextWithShadow(graphics, $"REB: {player.Rebounds}", font, Brushes.White, new PointF(10, yOffset));
                yOffset += lineSpacing;

                DrawTextWithShadow(graphics, $"STL: {player.Steals}", font, Brushes.White, new PointF(10, yOffset));
                yOffset += lineSpacing;

                DrawTextWithShadow(graphics, $"BLK: {player.Blocks}", font, Brushes.White, new PointF(10, yOffset));
                yOffset += lineSpacing;

                DrawTextWithShadow(graphics, $"TO: {player.Turnovers}", font, Brushes.Red, new PointF(10, yOffset)); // Turnovers in red
                yOffset += lineSpacing;

                DrawTextWithShadow(graphics, $"PF: {player.Fouls}", font, Brushes.White, new PointF(10, yOffset));
                yOffset += lineSpacing;

                DrawTextWithShadow(graphics, $"G: {player.GamesPlayed}", font, Brushes.White, new PointF(10, yOffset)); // Games played
            }
        }


        // Helper to get a brush based on stat thresholds
        private Brush GetStatBrush(float stat, float threshold = 25) => stat > threshold ? Brushes.Green : Brushes.Red;

        // Draws the team logo in the photo area
        private void DrawTeamLogo(Graphics graphics)
        {
            if (teamLogoBitmap != null)
            {
                const int logoSize = 120;
                int logoX = pictureBoxPhoto.Width - logoSize - 10; // 10px padding
                int logoY = 10;

                graphics.DrawImage(teamLogoBitmap, new Rectangle(logoX, logoY, logoSize, logoSize));
            }
        }


        // Retrieves the color associated with a team
        private Color GetTeamColor(string team) => TeamColors.TryGetValue(team, out var color) ? color : Color.Gray;

        private static readonly Dictionary<string, Color> TeamColors = new()
        {
            { "Lakers", ColorTranslator.FromHtml("#552583") },
            { "Suns", ColorTranslator.FromHtml("#E56020") },
            { "Bucks", ColorTranslator.FromHtml("#00471B") },
            { "Warriors", ColorTranslator.FromHtml("#1D428A") },
            { "76ers", ColorTranslator.FromHtml("#006BB6") },
            { "Mavericks", ColorTranslator.FromHtml("#007DC5") },
            { "Nuggets", ColorTranslator.FromHtml("#FBBF00") },
            { "Clippers", ColorTranslator.FromHtml("#C8102E") },
            { "Heat", ColorTranslator.FromHtml("#98002E") },
        };

        // Sets the first player as default selection
        private void SetDefaultPlayer()
        {
            if (playerManager.Players.FirstOrDefault() is Player firstPlayer)
            {
                listBoxPlayers.SelectedItem = firstPlayer;
                DisplayCard(firstPlayer);
                UpdateDataGridView(firstPlayer);
            }
        }


        // Configures column headers and ensures all stats are displayed
        private void CustomizeDataGridViewColumns()
        {
            dataGridView1.Columns["Name"].HeaderText = "Player Name";
            dataGridView1.Columns["Team"].HeaderText = "Team";
            dataGridView1.Columns["Points"].HeaderText = "Points";
            dataGridView1.Columns["Assists"].HeaderText = "Assists";
            dataGridView1.Columns["Rebounds"].HeaderText = "Rebounds";
            dataGridView1.Columns["Steals"].HeaderText = "Steals";
            dataGridView1.Columns["Blocks"].HeaderText = "Blocks";
            dataGridView1.Columns["Turnovers"].HeaderText = "Turnovers";
            dataGridView1.Columns["Fouls"].HeaderText = "Fouls";
            dataGridView1.Columns["GamesPlayed"].HeaderText = "Games Played";

            // Make sure all columns are visible
            dataGridView1.Columns["PhotoPath"].Visible = false; // Photo paths not needed in view
            dataGridView1.Columns["TeamLogoPath"].Visible = false; // Logo paths not needed in view
        }


        // Open the Add Player form when the "Add" button is clicked
        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(playerManager, RefreshPlayerList);
            form2.ShowDialog();
        }

        // Refresh the player list and DataGridView after adding a player
        private void RefreshPlayerList()
        {
            listBoxPlayers.DataSource = null; // Reset DataSource
            listBoxPlayers.DataSource = playerManager.Players; // Reassign the updated list
            listBoxPlayers.DisplayMember = "Name"; // Ensure the correct field is displayed
        }


        // Remove the selected player when the "Remove" button is clicked
        private void buttonRemovePlayer_Click(object sender, EventArgs e)
        {
            // Ensure a player is selected before attempting removal
            if (listBoxPlayers.SelectedItem is Player selectedPlayer)
            {
                // Confirm player removal
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to remove {selectedPlayer.Name}?",
                    "Confirm Removal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Find the index of the selected player
                    int selectedIndex = listBoxPlayers.SelectedIndex;

                    // Remove the selected player from the player list
                    playerManager.Players.Remove(selectedPlayer);
                    RefreshPlayerList();

                    // After removal, select the next player in the list (if available)
                    if (playerManager.Players.Count > 0)
                    {
                        // If the selected player was not the last one, select the next player
                        int newIndex = selectedIndex >= playerManager.Players.Count ? selectedIndex - 1 : selectedIndex;
                        listBoxPlayers.SelectedIndex = newIndex;
                    }
                    else
                    {
                        // If no players are left, clear the display
                        ClearDisplayCard();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a player to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // Helper method to clear the display card when no player is selected
        private void ClearDisplayCard()
        {
            pictureBoxPhoto.Image = null;
            panelCard.BackColor = Color.Gray;
            teamLogoBitmap = null; // Ensure the logo is cleared
            pictureBoxPhoto.Invalidate(); // Redraw the photo area
        }

        // Open the Update Player form when the "Update" button is clicked
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listBoxPlayers.SelectedItem is Player selectedPlayer)
            {
                Form2 form2 = new Form2(playerManager, RefreshPlayerList, selectedPlayer); // Pass the selected player
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a player to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



    }
}


// References:
// Players stats:
// LeBron James. (2024, November 12). In Wikipedia. https://en.wikipedia.org/wiki/LeBron_James
// Kevin Durant. (2024, November 13). In Wikipedia. https://en.wikipedia.org/wiki/Kevin_Durant
// Giannis Antetokounmpo. (2024, November 8). In Wikipedia. https://en.wikipedia.org/wiki/Giannis_Antetokounmpo
// Stephen Curry. (2024, November 14). In Wikipedia. https://en.wikipedia.org/wiki/Stephen_Curry
// Joel Embiid. (2024, November 15). In Wikipedia. https://en.wikipedia.org/wiki/Joel_Embiid
// Luka Dončić. (2024, November 16). In Wikipedia. https://en.wikipedia.org/wiki/Luka_Don%C4%8Di%C4%87
// Nikola Jokić. (2024, November 17). In Wikipedia. https://en.wikipedia.org/wiki/Nikola_Joki%C4%87
// Kawhi Leonard. (2024, November 18). In Wikipedia. https://en.wikipedia.org/wiki/Kawhi_Leonard
// Jimmy Butler. (2024, November 19). In Wikipedia. https://en.wikipedia.org/wiki/Jimmy_Butler
// Anthony Davis. (2024, November 20). In Wikipedia. https://en.wikipedia.org/wiki/Anthony_Davis
// Player Photos: https://www.gettyimages.ca/
// Logos:
// CleanPNG. (n.d.). CleanPNG - HD PNG images and illustrations. Free unlimited download. Retrieved November 13, 2024, from https://www.cleanpng.com/
// Dictionary - https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-9.0
//I used ChatGPT to assist me with writing the function below. I gave it the following prompt:
// Give me the stats for NBA Players based on wikipedia
// Put in comments
// Give me the hex colors for the NBA teams
// Help me improve my code
// Check my code syntax
// How do you paint the stats and logo in front of the photo