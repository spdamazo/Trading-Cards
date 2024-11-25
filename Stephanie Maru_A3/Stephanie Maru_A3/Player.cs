using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stephanie_Maru_A3
{
    // Class to represent a basketball player
    public class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public string PhotoPath { get; set; }
        public string TeamLogoPath { get; set; }
        public int Points { get; set; }
        public int Assists { get; set; }
        public int Rebounds { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int Turnovers { get; set; }
        public int Fouls { get; set; }
        public int GamesPlayed { get; set; }
    }
}

