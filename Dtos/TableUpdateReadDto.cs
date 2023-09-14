using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class TableUpdateReadDto
    {
        public int TableId { get; set; }

        public string? TableName { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}