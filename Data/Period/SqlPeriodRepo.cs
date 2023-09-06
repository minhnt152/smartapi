using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlPeriodRepo : IPeriodRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlPeriodRepo(SmAccessParkingContext context){
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreatePeriod(Period item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }
            _context.Periods.Add(item);
        }

        public void DelPeriod(Period item)
        {
             if(item==null){
                throw new ArgumentNullException(nameof(item));
            }
            _context.Periods.Remove(item);
        }

        public IEnumerable<Period> GetPeriodOnSchedule(int schId)
        {
            return _context.Periods.Where(item => item.SchId == schId).ToArray();
        }

    }
}