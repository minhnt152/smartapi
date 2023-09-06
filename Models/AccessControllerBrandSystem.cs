using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class AccessControllerBrandSystem
{
    public int BrId { get; set; }

    public string BrName { get; set; } = null!;

    public byte[]? Logo { get; set; }

    public virtual ICollection<AccessControllerModel> AccessControllerModels { get; set; } = new List<AccessControllerModel>();

    public virtual ICollection<AccessControllerNetwork> AccessControllerNetworks { get; set; } = new List<AccessControllerNetwork>();
}
