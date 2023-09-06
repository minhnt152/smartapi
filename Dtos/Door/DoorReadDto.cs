using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class DoorReadDto
    {
        public int DoorId { get; set; }

        public int? CnctCtrlrId { get; set; }

        public string DoorName { get; set; } = null!;

        public int LoTo { get; set; }

        public int DoTo { get; set; }

        public int? PInput { get; set; }

        public int? POutput { get; set; }

        public int? PButtonStt { get; set; }

        public int? PDoorStt { get; set; }

        public int? PLockCtrl { get; set; }

        public int? PSiren { get; set; }

        public int? PFireAlarm { get; set; }

        public bool? DoorEnable { get; set; }

        public string? Descr { get; set; }

    }
}