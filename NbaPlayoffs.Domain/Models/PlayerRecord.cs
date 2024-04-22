using System;
using System.Collections.Generic;

namespace NbaPlayoffs.Domain.Models;

public partial class PlayerRecord
{
    public int Id { get; set; }

    public int PlayerId { get; set; }

    public int TeamRecordId { get; set; }

    public int Points { get; set; }

    public int Rebounds { get; set; }

    public int GamesPlayed { get; set; }

    public virtual Player Player { get; set; } = null!;

    public virtual TeamRecord TeamRecord { get; set; } = null!;
}
