using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface IFacilityRepo{
        IEnumerable<Facility> GetAllFacilitys();
        Facility GetFacilityById(int id);
        void CreateFacility(Facility item);
        void UpdateFacility(Facility item);

        void AddHolder(int facId, CardHolder holder);
        void DelHolder(int facId, CardHolder holder);
               
        void DelFacility(Facility item);
        bool SaveChanges();    
    }
}