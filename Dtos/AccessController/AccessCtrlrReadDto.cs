using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class AccessCtrlrReadDto
    {
        public int CtrlrId { get; set; }

        public int? NetworkId { get; set; }

        public int? ModelId { get; set; }

        public int? ParentCtlr { get; set; }

        public string CtrlrName { get; set; } = null!;

        public string CtrlrMac { get; set; } = null!;

        public string CtrlrIp { get; set; } = null!;

        public string CtrlrSnm { get; set; } = null!;

        public string CtrlrDgw { get; set; } = null!;

        public int? CtrlrLnaddr { get; set; }

        public string? Descr { get; set; }

        public string? Ext1 { get; set; }

        public string? Ext2 { get; set; }

        public string? Ext3 { get; set; }

        public string? Ext4 { get; set; }

        public string? Ext5 { get; set; }

        public string? Ext6 { get; set; }

        public string? Ext7 { get; set; }

        public string? Ext8 { get; set; }

        public string? Ext9 { get; set; }

        public string? Ext10 { get; set; }
    }
}