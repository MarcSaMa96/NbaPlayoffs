using System;
using System.Collections.Generic;

namespace NbaPlayoffs.Domain.Models;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ConferenceId { get; set; }

    public string? ImageRoute { get; set; }

    public virtual Conference Conference { get; set; } = null!;

    public virtual ICollection<FavouriteTeam> FavouriteTeams { get; set; } = new List<FavouriteTeam>();

    public virtual ICollection<TeamRecord> TeamRecords { get; set; } = new List<TeamRecord>();
}
