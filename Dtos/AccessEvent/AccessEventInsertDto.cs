using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class AccessEventInsertDto
    {
        public DateTime? EventDate { get; set; }

        public string? CardNo { get; set; }

        public int? DoorId { get; set; }

         public int? EventCode { get; set; }

        public int? Direction { get; set; }

    }
}