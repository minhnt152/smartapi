using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class AccessRightInsertDto
    {       

        public int? SchId { get; set; }

        public string? RightName { get; set; }

        public bool? IsEnable { get; set; }

        public string? Descr { get; set; }

    }
}