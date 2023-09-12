using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class CardHolder
{
    public int ChId { get; set; }

    public int? FacId { get; set; }

    public string ChFname { get; set; } = null!;

    public string ChLname { get; set; } = null!;

    public DateTime? ChDob { get; set; }

    /// <summary>
    /// 0 = Male; 1 = Female; 2 = Other
    /// </summary>
    public int? ChGender { get; set; }

    public string ChAddr { get; set; } = null!;

    public string ChTel { get; set; } = null!;

    public string? ChEmail { get; set; }

    public byte[]? ChPhotos { get; set; }

    public int? ChType { get; set; }

    public virtual ICollection<AccessEvent> AccessEvents { get; set; } = new List<AccessEvent>();

    public virtual ICollection<AccessRightHolder> AccessRightHolders { get; set; } = new List<AccessRightHolder>();

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual CitizenIdCard? CitizenIdCard { get; set; }

    public virtual Facility? Fac { get; set; }
}
