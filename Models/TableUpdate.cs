using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class TableUpdate
{
    public int TableId { get; set; }

    public string? TableName { get; set; }

    public DateTime? LastUpdate { get; set; }
}
