using System;
using System.Collections.Generic;

namespace NbaPlayoffs.Domain.Models;

public partial class PlayoffRank
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<PlayoffGuess> PlayoffGuesses { get; set; } = new List<PlayoffGuess>();
}
