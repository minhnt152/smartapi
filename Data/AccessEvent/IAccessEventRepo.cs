using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface IAccessEventRepo{
        IEnumerable<AccessEvent> GetAccessEvents(DateTime? startDate, DateTime? endDate,string? cardNo,int? chId, string? chName, string? doorName, int? eventStt, int? orient, int pos, out int lastPos, out bool hasMore);
        AccessEvent GetAccessEventById(int id);
        void CreateAccessEvent(AccessEvent item);
        bool SaveChanges();    
    }
}