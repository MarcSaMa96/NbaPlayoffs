using System;
using System.Collections.Generic;

namespace NbaPlayoffs.Domain.Models;

public partial class TeamRecord
{
    public int Id { get; set; }

    public int TeamId { get; set; }

    public int Year { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }

    public virtual ICollection<PlayerRecord> PlayerRecords { get; set; } = new List<PlayerRecord>();

    public virtual ICollection<PlayoffGuess> PlayoffGuesses { get; set; } = new List<PlayoffGuess>();

    public virtual Team Team { get; set; } = null!;
}
