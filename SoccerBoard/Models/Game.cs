using System;
using System.Collections.Generic;

namespace SoccerBoard.Models
{
    public class Game:Base
    {
        
        public object Round { get; set; }
        public int RoundNumber { get; set; }
        public DateTime? MatchDate { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public int Status { get; set; }
        public int PlayedMinutes { get; set; }
        public object SecondHalfStarted { get; set; }
        public DateTime? GameStarted { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }
        public List<object> PeriodResults { get; set; }
        public bool OnlyResultAvailable { get; set; }
        public int Season { get; set; }
        public string Country { get; set; }
        public string League { get; set; }
    }
}
