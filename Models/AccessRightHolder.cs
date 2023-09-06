using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class AccessRightHolder
{
    public int Id { get; set; }

    public int? RightId { get; set; }

    public int? ChId { get; set; }

    public virtual CardHolder? Ch { get; set; }

    public virtual AccessRight? Right { get; set; }
}
