using System;
using System.Collections.Generic;
using System.Text;

namespace RandomTeamGenerator
{
    public class Team
    {
        private string teamName;
        private List<string> member = new List<string>();

        public Team(string teamName) { this.teamName = teamName; }
        public List<string> Member { get { return member; } set { member = value; } }

        public override string ToString()
        {
            return $"{teamName}:";
        }

    }
}
