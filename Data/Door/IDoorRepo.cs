using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface IDoorRepo{
        IEnumerable<Door> GetAllDoors();
        IEnumerable<Door> GetDoorsByName(string name);
        IEnumerable<Door> GetDoorsByCtrlrId(int id);
        Door GetDoorById(int id);
        void CreateDoor(Door item);
        void UpdateDoor(Door item);
        void DelDoor(Door item);
        bool SaveChanges();    
    }
}