using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class Schedule
{
    public int SchId { get; set; }

    public string SchName { get; set; } = null!;

    public bool? SchEnable { get; set; }

    public string? Descr { get; set; }

    public virtual ICollection<AccessRight> AccessRights { get; set; } = new List<AccessRight>();

    public virtual ICollection<Period> Periods { get; set; } = new List<Period>();
}
