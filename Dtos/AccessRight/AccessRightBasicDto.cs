using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class AccessRightBasicDto
    {
        public int RightId { get; set; }
        public int SchId { get; set; }

        public string SchName { get; set; } = null!;

        public bool? SchEnable { get; set; }

        public string? Descr { get; set; }

    }
}