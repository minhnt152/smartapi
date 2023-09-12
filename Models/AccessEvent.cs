using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class AccessEvent
{
    public int EventId { get; set; }

    public DateTime? EventDate { get; set; }

    public string? CardNo { get; set; }

    /// <summary>
    /// Card holder full name
    /// </summary>
    public string? ChName { get; set; }

    public int? DoorId { get; set; }

    public string? DoorName { get; set; }

    /// <summary>
    /// 0=Granted; 1=Not grant; 2=Other
    /// </summary>
    public int? EventStt { get; set; }

    /// <summary>
    /// 0=In; 1=Out
    /// </summary>
    public int? Orientation { get; set; }

    public int? CardId { get; set; }

    public int? ChId { get; set; }

    public virtual Card? Card { get; set; }

    public virtual CardHolder? Ch { get; set; }

    public virtual Door? Door { get; set; }
}
