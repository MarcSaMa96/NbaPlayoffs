using NbaPlayoffs.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaPlayoffs.Services.DTOs
{
    public class PlayoffTeamDto
    {
        public int TeamRecordId { get; set; }
        public int PlayoffRank { get; set; } = (int)PlayoffRankEnum.FirstRound;
        public string TeamName { get; set; }
        public int BracketGroup { get; set; }
        public int Bracket { get; set; }

    }
}
