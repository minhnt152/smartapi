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

    /// <summary>
    /// Start time
    /// </summary>
    public DateTime? Stime { get; set; }

    /// <summary>
    /// End time
    /// </summary>
    public DateTime? Etime { get; set; }

    public virtual Schedule? Sch { get; set; }
}
