using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class ScheduleUpdateDto
    {

        public string SchName { get; set; } = null!;

        public bool? SchEnable { get; set; }

        public string? Descr { get; set; }
        
        public virtual ICollection<PeriodInsertDto> Periods { get; set; } = new List<PeriodInsertDto>();

    }
}