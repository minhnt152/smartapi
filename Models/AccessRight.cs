using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class AccessRight
{
    public int RightId { get; set; }

    public int? SchId { get; set; }

    public string? RightName { get; set; }

    public bool? IsEnable { get; set; }

    public string? Descr { get; set; }

    public virtual ICollection<AccessRightDoor> AccessRightDoors { get; set; } = new List<AccessRightDoor>();

    public virtual ICollection<AccessRightHolder> AccessRightHolders { get; set; } = new List<AccessRightHolder>();

    public virtual Schedule? Sch { get; set; }
}
