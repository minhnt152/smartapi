using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface IAccessRightRepo{
        IEnumerable<AccessRight> GetAllAccessRights();
        AccessRight GetAccessRightById(int id);
        void CreateAccessRight(AccessRight item);
        void UpdateAccessRight(AccessRight item);

        void AddDoorToRight(int rightid, int DoorId);
        void DelDoorInRight(int rightId, int DoorId);
               
        void DelAccessRight(AccessRight item);
        bool SaveChanges();    
    }
}