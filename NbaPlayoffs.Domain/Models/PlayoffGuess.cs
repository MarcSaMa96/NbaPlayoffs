using System;
using System.Collections.Generic;

namespace NbaPlayoffs.Domain.Models;

public partial class PlayoffGuess
{
    public int Id { get; set; }

    public int TeamRecordId { get; set; }

    public int PlayoffRankId { get; set; }

    public int PlayoffGuessHeaderId { get; set; }

    public virtual PlayoffGuessHeader PlayoffGuessHeader { get; set; } = null!;

    public virtual PlayoffRank PlayoffRank { get; set; } = null!;

    public virtual TeamRecord TeamRecord { get; set; } = null!;
}
