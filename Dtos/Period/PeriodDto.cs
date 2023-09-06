using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class PeriodDto
    {
        public int PrdId { get; set; }

        public int? SchId { get; set; }

        public int WeekDay { get; set; }

        public DateTime? Stime { get; set; }

        public DateTime? Etime { get; set; }
    }
}