using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlDoorRepo : IDoorRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlDoorRepo(SmAccessParkingContext context){
            _context = context;
        }

        public void CreateDoor(Door item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }
            _context.Doors.Add(item);
        }

        public void DelDoor(Door item)
        {
             if(item==null){
                throw new ArgumentNullException(nameof(item));
            }

            _context.Doors.Remove(item);
        }

        public IEnumerable<Door> GetAllDoors()
        {
            return _context.Doors.ToArray();
        }

        public Door GetDoorById(int id)
        {
            return _context.Doors.FirstOrDefault(item => item.DoorId == id);
        }

        public IEnumerable<Door> GetDoorsByCtrlrId(int id)
        {
            return _context.Doors.Where(item => item.CnctCtrlrId == id).ToArray();
        }

        public IEnumerable<Door> GetDoorsByName(string name)
        {
            return _context.Doors.Where(item => item.DoorName.ToLower().Contains(name.ToLower())).ToArray();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateDoor(Door item)
        {
            Door item1 = _context.Doors.Single(a => a.DoorId == item.DoorId);
            item1 = item;
        }
    }
}