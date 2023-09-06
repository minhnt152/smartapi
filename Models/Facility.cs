using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class Facility
{
    public int FacId { get; set; }

    public int? ParentFacId { get; set; }

    public string? FacName { get; set; }

    public byte[]? FacLogo { get; set; }

    public string? FacAddr { get; set; }

    public string? FacPhoneNo { get; set; }

    public string? EmailAddr { get; set; }

    public virtual ICollection<CardHolder> CardHolders { get; set; } = new List<CardHolder>();

    public virtual ICollection<Facility> InverseParentFac { get; set; } = new List<Facility>();

    public virtual Facility? ParentFac { get; set; }
}
