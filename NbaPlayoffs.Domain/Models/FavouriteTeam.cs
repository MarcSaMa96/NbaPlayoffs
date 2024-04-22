using System;
using System.Collections.Generic;

namespace NbaPlayoffs.Domain.Models;

public partial class FavouriteTeam
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public int IdTeam { get; set; }

    public virtual Team IdTeamNavigation { get; set; } = null!;
}
