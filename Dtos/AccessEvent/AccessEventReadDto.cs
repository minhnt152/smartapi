using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class AccessEventReadDto
    {
        public int EventId { get; set; }

        public DateTime? EventDate { get; set; }

        public int? CardId { get; set; }

        public string? CardNo { get; set; }

        public string? ChName { get; set; }

        public int? DoorId { get; set; }

        public string? DoorName { get; set; }

        public int? EventStt { get; set; }

        public int? Orientation { get; set; }

    }
}