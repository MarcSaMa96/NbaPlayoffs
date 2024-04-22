using System;
using System.Collections.Generic;

namespace NbaPlayoffs.Domain.Models;

public partial class PlayoffGuessHeader
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<PlayoffGuess> PlayoffGuesses { get; set; } = new List<PlayoffGuess>();
}
