using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlAccessEventRepo : IAccessEventRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlAccessEventRepo(SmAccessParkingContext context){
            _context = context;
        }
        
        public void CreateAccessEvent(AccessEvent item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }

            Card card = _context.Cards.FirstOrDefault(x=>x.CardNo == item.CardNo);
            if (card != null)
            {
                item.CardId = card.CardId;
            }

            CardHolder holder = _context.CardHolders.FirstOrDefault(x=>x.Cards.Contains(card));
            if (holder != null)
            {
            item.ChId = holder.ChId;
            item.ChName = holder.ChFname + " " + holder.ChLname;
            }

            Door door = _context.Doors.FirstOrDefault(x=>x.DoorId == item.DoorId);
            if (door != null)
            {
                item.DoorName = door.DoorName;
            }

            item.DbDateTime = DateTime.Now;

            _context.AccessEvents.Add(item);
        }

        public AccessEvent GetAccessEventById(int id)
        {
            return _context.AccessEvents.FirstOrDefault(item => item.EventId == id);
        }

        public IEnumerable<AccessEvent> GetAccessEvents(DateTime? startDate, DateTime? endDate,DateTime? dbStartDate, DateTime? dbEndDate, string? cardNo,int? chId, string? chName, string? doorName, int? eventStt, int? orient, int pos, out int lastPos, out bool hasMore)
        {
            int count = 5;
            if(pos<0) pos=0;
            if (startDate ==null) startDate = new DateTime(1970,01,01);
            if (endDate ==null) endDate = DateTime.Today.AddDays(1);

            if (dbStartDate ==null) dbStartDate = new DateTime(1970,01,01);
            if (dbEndDate ==null) dbEndDate = DateTime.Today.AddDays(1);

            lastPos = 0;
            hasMore =false;

            var events = _context.AccessEvents.Where(x=> (x.EventDate>startDate && x.EventDate <=endDate) &&
                                                    (x.DbDateTime>dbStartDate && x.DbDateTime <=dbEndDate) &&
                                                    (cardNo==null||x.CardNo==cardNo) &&
                                                    (chId==null||x.CardId==chId) &&
                                                    (chName==null||x.ChName.ToLower().Contains(chName.ToLower())) &&
                                                    (doorName==null||x.DoorName.ToLower().Contains(doorName.ToLower())) &&
                                                    (eventStt==null||x.EventStt==eventStt) &&
                                                    (orient==null||x.Orientation==orient)
            ).OrderBy(x => x.EventId)
            .Skip(pos)
            .Take(count)
            .ToList();

            if(events.Count()>=count)
            {
                lastPos = pos+count;
                hasMore = true;
            }
            else
            {
                lastPos = pos + events.Count();
                hasMore = false;
            }

            return events;

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}