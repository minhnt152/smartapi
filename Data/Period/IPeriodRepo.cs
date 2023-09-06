using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface IPeriodRepo{
        IEnumerable<Period> GetPeriodOnSchedule(int schId);
        void CreatePeriod(Period item);
        void DelPeriod(Period item);

        bool SaveChanges();
    
    }
}