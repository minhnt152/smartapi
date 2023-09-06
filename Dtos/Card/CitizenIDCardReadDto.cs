using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class CitizenIDCardReadDto
    {
        public string? IdNo { get; set; }

        public string? Nationality { get; set; }

        public string? PlaceOfOrigin { get; set; }

        public DateOnly? DateOfIssue { get; set; }

        public string? PlaceOfIssue { get; set; }
    }
}