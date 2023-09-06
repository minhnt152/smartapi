using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class Card
{
    public int CardId { get; set; }

    public int? ChId { get; set; }

    public string PrintCardId { get; set; } = null!;

    /// <summary>
    /// 0=Daily; 1=Monthly
    /// </summary>
    public int CardType { get; set; }

    /// <summary>
    /// 0=Normal; 1=Lost...
    /// </summary>
    public int CardState { get; set; }

    public string CardNo { get; set; } = null!;

    public DateOnly IssDate { get; set; }

    public DateOnly VldDate { get; set; }

    public DateOnly ExpDate { get; set; }

    public string? Descr { get; set; }

    public virtual ICollection<AccessEvent> AccessEvents { get; set; } = new List<AccessEvent>();

    public virtual CardHolder? Ch { get; set; }
}
