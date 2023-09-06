using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface IAccessCtrlrRepo{
        IEnumerable<AccessController> GetAllCtrlr();
        AccessController GetCtrlrById(int id);
        void AddDoor(int id, Door door);
        void DelDoor(int id, Door door);
        void CreateCtrlr(AccessController item);
        void UpdateCtrlr(AccessController item);
        void DelCtrlr(AccessController item);
        bool SaveChanges();    
       
    }
}