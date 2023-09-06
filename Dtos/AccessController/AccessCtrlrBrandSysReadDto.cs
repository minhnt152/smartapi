using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class AccessCtrlrBrandSysReadDto
    {
        public int BrId { get; set; }

        public string BrName { get; set; } = null!;

        public byte[]? Logo { get; set; }

    }
}