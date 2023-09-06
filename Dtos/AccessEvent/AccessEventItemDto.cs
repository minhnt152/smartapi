using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class AccessEventItemDto
    {
        public int position { get; set; }
        public bool hasMore { get; set; }
        public virtual ICollection<AccessEventReadDto> Events { get; set; } = new List<AccessEventReadDto>();
    }
}