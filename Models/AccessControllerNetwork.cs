using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class AccessControllerNetwork
{
    public int NetworkId { get; set; }

    public int? BrId { get; set; }

    public string? NetworkName { get; set; }

    public string? Ext1 { get; set; }

    public string? Ext2 { get; set; }

    public string? Ext3 { get; set; }

    public string? Ext4 { get; set; }

    public string? Ext5 { get; set; }

    public string? Ext6 { get; set; }

    public string? Ext7 { get; set; }

    public string? Ext8 { get; set; }

    public string? Ext9 { get; set; }

    public string? Ext10 { get; set; }

    public string? Adapter { get; set; }

    public virtual ICollection<AccessController> AccessControllers { get; set; } = new List<AccessController>();

    public virtual AccessControllerBrandSystem? Br { get; set; }
}
