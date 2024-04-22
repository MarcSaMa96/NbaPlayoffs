using System;
using System.Collections.Generic;

namespace NbaPlayoffs.Domain.Models;

public partial class Player
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int PlayerPositionId { get; set; }

    public virtual PlayerPosition PlayerPosition { get; set; } = null!;

    public virtual ICollection<PlayerRecord> PlayerRecords { get; set; } = new List<PlayerRecord>();
}
