using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Dtos;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlFacilityRepo : IFacilityRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlFacilityRepo(SmAccessParkingContext context){
            _context = context;
        }

        public void AddHolder(int facId, CardHolder holder)
        {
            CardHolder item = _context.CardHolders.FirstOrDefault(x=>x.ChId==holder.ChId);
            if(item!=null)
            {
                item.FacId=facId;
            }
        }

        public void CreateFacility(Facility item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }            
            _context.Facilities.Add(item);
        }

        public void DelFacility(Facility item)
        {
            _context.Facilities.Remove(item);
        }

        public void DelHolder(int facId, CardHolder holder)
        {
            CardHolder item = _context.CardHolders.FirstOrDefault(x=>x.ChId==holder.ChId);
            if(item.FacId==facId)
            {
                item.FacId=null;
            }
        }

        public IEnumerable<Facility> GetAllFacilitys()
        {
            return _context.Facilities.ToArray();
        }

        public Facility GetFacilityById(int id)
        {
            return _context.Facilities.FirstOrDefault(item => item.FacId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateFacility(Facility item)
        {
            Facility item1 = _context.Facilities.Single(a => a.FacId == item.FacId);
            item1=item;
        }
    }
}