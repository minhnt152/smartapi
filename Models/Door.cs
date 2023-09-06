using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class Door
{
    public int DoorId { get; set; }

    public int? CnctCtrlrId { get; set; }

    public string DoorName { get; set; } = null!;

    /// <summary>
    /// LO time out
    /// </summary>
    public int LoTo { get; set; }

    /// <summary>
    /// DO time out
    /// </summary>
    public int DoTo { get; set; }

    public int? PInput { get; set; }

    public int? POutput { get; set; }

    public int? PButtonStt { get; set; }

    public int? PDoorStt { get; set; }

    public int? PLockCtrl { get; set; }

    public int? PSiren { get; set; }

    public int? PFireAlarm { get; set; }

    public bool? DoorEnable { get; set; }

    public string? Descr { get; set; }

    public virtual ICollection<AccessEvent> AccessEvents { get; set; } = new List<AccessEvent>();

    public virtual ICollection<AccessRightDoor> AccessRightDoors { get; set; } = new List<AccessRightDoor>();

    public virtual AccessController? CnctCtrlr { get; set; }
}
