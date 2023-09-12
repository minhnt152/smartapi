using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class PeriodInsertDto
    {
        public int WeekDay { get; set; }

        public int? StartHour { get; set; }

        public int? StartMinute { get; set; }

        public int? EndHour { get; set; }

        public int? EndMinute { get; set; }
    }
}