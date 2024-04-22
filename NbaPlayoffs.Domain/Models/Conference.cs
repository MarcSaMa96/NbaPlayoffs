using System;
using System.Collections.Generic;

namespace NbaPlayoffs.Domain.Models;

public partial class Conference
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
