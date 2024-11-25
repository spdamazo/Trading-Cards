using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Stephanie_Maru_A3.Form1;

namespace Stephanie_Maru_A3
{
    public class PlayerManager
    {
        // A list to store all player objects
        public List<Player> Players { get; private set; }

        // Constructor to initialize the list of players with some predefined data
        public PlayerManager()
        {
            Players = new List<Player>
            {
                new Player { Name = "LeBron James", Team = "Lakers", PhotoPath = @"Images\lebron.jpg", TeamLogoPath = @"Logos\lakers_logo.png", Points = 25, Assists = 7, Rebounds = 8, Steals = 1, Blocks = 0, Turnovers = 3, Fouls = 2, GamesPlayed = 20 },
                new Player { Name = "Kevin Durant", Team = "Suns", PhotoPath = @"Images\kevin_durant.jpg", TeamLogoPath = @"Logos\suns_logo.png", Points = 27, Assists = 5, Rebounds = 7, Steals = 0, Blocks = 1, Turnovers = 2, Fouls = 3, GamesPlayed = 19 },
                new Player { Name = "Giannis", Team = "Bucks", PhotoPath = @"Images\giannis.jpg", TeamLogoPath = @"Logos\bucks_logo.png", Points = 29, Assists = 6, Rebounds = 12, Steals = 1, Blocks = 2, Turnovers = 4, Fouls = 1, GamesPlayed = 22 },
                new Player { Name = "Stephen Curry", Team = "Warriors", PhotoPath = @"Images\stephen_curry.jpg", TeamLogoPath = @"Logos\warriors_logo.png", Points = 32, Assists = 6, Rebounds = 5, Steals = 1, Blocks = 0, Turnovers = 4, Fouls = 2, GamesPlayed = 21 },
                new Player { Name = "Joel Embiid", Team = "76ers", PhotoPath = @"Images\joel_embiid.jpg", TeamLogoPath = @"Logos\76ers_logo.png", Points = 33, Assists = 4, Rebounds = 11, Steals = 1, Blocks = 1, Turnovers = 3, Fouls = 2, GamesPlayed = 18 },
                new Player { Name = "Luka Dončić", Team = "Mavericks", PhotoPath = @"Images\luka_doncic.jpg", TeamLogoPath = @"Logos\mavericks_logo.png", Points = 28, Assists = 9, Rebounds = 8, Steals = 1, Blocks = 0, Turnovers = 5, Fouls = 3, GamesPlayed = 20 },
                new Player { Name = "Nikola Jokić", Team = "Nuggets", PhotoPath = @"Images\nikola_jokic.jpg", TeamLogoPath = @"Logos\nuggets_logo.png", Points = 25, Assists = 8, Rebounds = 10, Steals = 1, Blocks = 1, Turnovers = 3, Fouls = 2, GamesPlayed = 22 },
                new Player { Name = "Kawhi Leonard", Team = "Clippers", PhotoPath = @"Images\kawhi_leonard.jpg", TeamLogoPath = @"Logos\clippers_logo.png", Points = 26, Assists = 5, Rebounds = 7, Steals = 2, Blocks = 1, Turnovers = 2, Fouls = 1, GamesPlayed = 19 },
                new Player { Name = "Jimmy Butler", Team = "Heat", PhotoPath = @"Images\jimmy_butler.jpg", TeamLogoPath = @"Logos\heat_logo.png", Points = 27, Assists = 5, Rebounds = 6, Steals = 2, Blocks = 0, Turnovers = 4, Fouls = 3, GamesPlayed = 20 },
                new Player { Name = "Anthony Davis", Team = "Lakers", PhotoPath = @"Images\anthony_davis.jpg", TeamLogoPath = @"Logos\lakers_logo.png", Points = 24, Assists = 3, Rebounds = 12, Steals = 1, Blocks = 2, Turnovers = 2, Fouls = 1, GamesPlayed = 21 }
            };
        }

        // Method to get a player by their name
        public Player GetPlayerByName(string name)
        {
            // Use LINQ to search for the player by name. Returns null if not found.
            return Players.FirstOrDefault(p => p.Name == name);
        }

        // Method to add a new player to the list
        public void AddPlayer(Player player)
        {
            // Check if a player with the same name already exists in the list
            if (Players.Any(p => p.Name == player.Name))
            {
                throw new ArgumentException("Player with the same name already exists."); // Throw an exception if the player exists
            }

            Players.Add(player); // Add the new player to the list
        }

        // Method to update an existing player's data
        public void UpdatePlayer(Player updatedPlayer)
        {
            // Find the player in the list by name
            var player = Players.FirstOrDefault(p => p.Name == updatedPlayer.Name);

            // If the player is found, update their details
            if (player != null)
            {
                player.Team = updatedPlayer.Team;
                player.PhotoPath = updatedPlayer.PhotoPath;
                player.TeamLogoPath = updatedPlayer.TeamLogoPath;
                player.Points = updatedPlayer.Points;
                player.Assists = updatedPlayer.Assists;
                player.Rebounds = updatedPlayer.Rebounds;
                player.Steals = updatedPlayer.Steals;
                player.Blocks = updatedPlayer.Blocks;
                player.Turnovers = updatedPlayer.Turnovers;
                player.Fouls = updatedPlayer.Fouls;
                player.GamesPlayed = updatedPlayer.GamesPlayed;
            }
            else
            {
                // If the player is not found, throw an exception
                throw new ArgumentException("Player not found.");
            }
        }
    }
}
