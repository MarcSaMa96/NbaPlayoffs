using System;
using System.Collections.Generic;

namespace NbaPlayoffs.Domain.Models;

public partial class PlayerPosition
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
