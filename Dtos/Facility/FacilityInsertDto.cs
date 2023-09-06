using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class FacilityInsertDto
    {

        public int? ParentFacId { get; set; }

        public string? FacName { get; set; }

        public byte[]? FacLogo { get; set; }

        public string? FacAddr { get; set; }

        public string? FacPhoneNo { get; set; }

        public string? EmailAddr { get; set; }

    }
}