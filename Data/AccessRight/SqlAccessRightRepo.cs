using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Dtos;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlAccessRightRepo : IAccessRightRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlAccessRightRepo(SmAccessParkingContext context){
            _context = context;
        }

        public void CreateAccessRight(AccessRight item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }            
            _context.AccessRights.Add(item);
        }

        public void AddDoorToRight(int rightid, int DoorId)
        {
            AccessRightDoor accessRightDoor = new AccessRightDoor();
            accessRightDoor.RightId = rightid;
            accessRightDoor.DoorId = DoorId;
            _context.AccessRightDoors.Add(accessRightDoor);          
            
        }

        public void DelDoorInRight(int rightid, int DoorId){
            
            _context.AccessRightDoors.Remove( _context.AccessRightDoors.FirstOrDefault(x=>x.DoorId==DoorId&&x.RightId==rightid));
        }

        public void DelAccessRight(AccessRight item)
        {
            _context.AccessRightDoors.RemoveRange(_context.AccessRightDoors.Where(x=>x.RightId == item.RightId));
            _context.AccessRightHolders.RemoveRange(_context.AccessRightHolders.Where(x=>x.RightId == item.RightId));
            _context.AccessRights.Remove(item);
        }

        public AccessRight GetAccessRightById(int id)
        {
          return _context.AccessRights.FirstOrDefault(item => item.RightId == id);
        }

        public IEnumerable<AccessRight> GetAllAccessRights()
        {
            return _context.AccessRights.ToArray();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAccessRight(AccessRight item)
        {
            AccessRight item1 = _context.AccessRights.Single(a => a.RightId == item.RightId);
            item1=item;
        }
    }
}