using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class AccessHolderSchedule
{
    public int? HolderId { get; set; }

    public int? SchId { get; set; }

    public virtual CardHolder? Holder { get; set; }

    public virtual Schedule? Sch { get; set; }
}
