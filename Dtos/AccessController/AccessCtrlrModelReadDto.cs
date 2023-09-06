using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class AccessCtrlrModelReadDto
    {
        public int ModelId { get; set; }

        public int? BrId { get; set; }

        public string? ModelName { get; set; }

        public int? ReaderQty { get; set; }

        public int? OutQty { get; set; }

        public int? InputQty { get; set; }

        public string? PartNo { get; set; }

        public string? UserGuide { get; set; }

        public string? Catalog { get; set; }

        public string? Descr { get; set; }

    }
}