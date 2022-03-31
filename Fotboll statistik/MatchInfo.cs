using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotboll_statistik
{
    class MatchInfo
    {
        public string JonnyTeam { get; }
        public string AdamTeam { get; }
        public int JonnyScore { get; }
        public int AdamScore { get; }
        public DateTime Date { get; }
        public int MatchNr { get; }

        public MatchInfo(DateTime date, int matchNr, string jonnyTeam, int jonnyScore, string adamTeam, int adamScore)
        {
            Date = date;
            MatchNr = matchNr;
            JonnyTeam = jonnyTeam;
            JonnyScore = jonnyScore;
            AdamTeam = adamTeam;
            AdamScore = adamScore;
        }

        public override string ToString()
        {
            return $"Match {MatchNr}, {Date:d MMM-yyyy}: {JonnyTeam} {JonnyScore} - {AdamTeam} {AdamScore}";
        }
    }
}
