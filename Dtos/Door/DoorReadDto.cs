using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class DoorReadDto
    {
        public int DoorId { get; set; }
        public int? ControllerId { get; set; }

        public string DoorName { get; set; } = null!;
        public int? DoorMode { get; set; }

        public int LoTo { get; set; }

        public int DoTo { get; set; }

        public int? PEntranceReader { get; set; }

        public int? PExitReader { get; set; }

        public int? PRexButton { get; set; }

        public int? PDoor1Status { get; set; }
        public int? PDoor2Status { get; set; }

        public int? PLock { get; set; }

        public int? PSiren { get; set; }

        public int? PFireAlarm { get; set; }

        public bool? DoorEnable { get; set; }

        public string? Description { get; set; }

    }
}