using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class AccessControllerModel
{
    public int ModelId { get; set; }

    public int? BrId { get; set; }

    public string? ModelName { get; set; }

    public int? ReaderQty { get; set; }

    public int? OutQty { get; set; }

    public int? InputQty { get; set; }

    public string? PartNo { get; set; }

    public string? UserGuide { get; set; }

    public string? Catalog { get; set; }

    public string? Descr { get; set; }

    public virtual ICollection<AccessController> AccessControllers { get; set; } = new List<AccessController>();

    public virtual AccessControllerBrandSystem? Br { get; set; }
}
