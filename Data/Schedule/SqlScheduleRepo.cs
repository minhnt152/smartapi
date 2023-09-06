using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlScheduleRepo : IScheduleRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlScheduleRepo(SmAccessParkingContext context){
            _context = context;
        }

        public void CreateSchedule(Schedule item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }
            _context.Schedules.Add(item);
        }

        public void DelSchedule(Schedule item)
        {
            if(item==null){
                throw new ArgumentNullException(nameof(item));
            }

            _context.Schedules.Remove(item);
        }

        public Schedule GetSchedulekById(int id)
        {
            return _context.Schedules.FirstOrDefault(item => item.SchId == id);
        }

        public IEnumerable<Schedule> GetAllSchedules()
        {
            return _context.Schedules.ToArray();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSchedule(Schedule item)
        {
            Schedule item1 = _context.Schedules.Single(a => a.SchId == item.SchId);
            item1.SchName = item.SchName;        
            item1.Descr = item.Descr;  
            item1.SchEnable = item.SchEnable;  
           
            var prds = _context.Periods.Where(e => e.SchId == item.SchId);
            _context.Periods.RemoveRange(prds); 
            _context.Periods.AddRange(item.Periods);              
        }
    }
}