using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class AccessController
{
    public int CtrlrId { get; set; }

    public int? NetworkId { get; set; }

    public int? ModelId { get; set; }

    public int? ParentCtlr { get; set; }

    public string CtrlrName { get; set; } = null!;

    public string CtrlrMac { get; set; } = null!;

    public string CtrlrIp { get; set; } = null!;

    /// <summary>
    /// subnet mask
    /// </summary>
    public string CtrlrSnm { get; set; } = null!;

    /// <summary>
    /// default gateway
    /// </summary>
    public string CtrlrDgw { get; set; } = null!;

    /// <summary>
    /// line address
    /// </summary>
    public int? CtrlrLnaddr { get; set; }

    public string? Descr { get; set; }

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

    public virtual ICollection<Door> Doors { get; set; } = new List<Door>();

    public virtual ICollection<AccessController> InverseParentCtlrNavigation { get; set; } = new List<AccessController>();

    public virtual AccessControllerModel? Model { get; set; }

    public virtual AccessControllerNetwork? Network { get; set; }

    public virtual AccessController? ParentCtlrNavigation { get; set; }
}
