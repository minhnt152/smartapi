using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class ScheduleReadDto
    {
        public int SchId { get; set; }

        public string SchName { get; set; } = null!;

        public bool? SchEnable { get; set; }

        public string? Descr { get; set; }

        public virtual ICollection<PeriodDto> Periods { get; set; } = new List<PeriodDto>();
    }
}