using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface IScheduleRepo{
        IEnumerable<Schedule> GetAllSchedules();
        Schedule GetSchedulekById(int id);
        void CreateSchedule(Schedule item);
        void UpdateSchedule(Schedule item);
        void DelSchedule(Schedule item);
        bool SaveChanges();    
    }
}