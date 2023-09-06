using System;
using System.Collections.Generic;

namespace smartapi.Models;

public partial class CitizenIdCard
{
    public int ChId { get; set; }

    public string? IdNo { get; set; }

    public string? Nationality { get; set; }

    public string? PlaceOfOrigin { get; set; }

    public DateOnly? DateOfIssue { get; set; }

    public string? PlaceOfIssue { get; set; }

    public virtual CardHolder Ch { get; set; } = null!;
}
