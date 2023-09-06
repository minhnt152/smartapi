using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Dtos
{
    public class PeriodInsertDto
    {
        public int WeekDay { get; set; }

        public DateTime? Stime { get; set; }

        public DateTime? Etime { get; set; }
    }
}