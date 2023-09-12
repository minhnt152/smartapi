using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class Period
{
    public int PrdId { get; set; }

    public int? SchId { get; set; }

    /// <summary>
    /// Sun=0; Mon=1...; Sat=6
    /// </summary>
    public int WeekDay { get; set; }

    public int? StartHour { get; set; }

    public int? StartMinute { get; set; }

    public int? EndHour { get; set; }

    public int? EndMinute { get; set; }

    public virtual Schedule? Sch { get; set; }
}
