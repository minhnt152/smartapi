using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlAccessCtrlrRepo : IAccessCtrlrRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlAccessCtrlrRepo(SmAccessParkingContext context){
            _context = context;
        }

        public void AddDoor(int id, Door door)
        {
            Door item = _context.Doors.FirstOrDefault(x=>x.DoorId==door.DoorId);
            if(item!=null)
            {
                item.CnctCtrlrId=id;
            }
        }

        public void CreateCtrlr(AccessController item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }            
            _context.AccessControllers.Add(item);
            _context.TableUpdates.FirstOrDefault(x=>x.TableId==2).LastUpdate = DateTime.Now;
        }

        public void DelCtrlr(AccessController item)
        {
            _context.AccessControllers.Remove(item);
            _context.TableUpdates.FirstOrDefault(x=>x.TableId==2).LastUpdate = DateTime.Now;
        }

        public void DelDoor(int id, Door door)
        {
            Door item = _context.Doors.FirstOrDefault(x=>x.DoorId==door.DoorId);
            if(item.CnctCtrlrId==id)
            {
                item.CnctCtrlrId=null;
            }
        }

        public IEnumerable<AccessController> GetAllCtrlr()
        {
            return _context.AccessControllers.ToArray();
        }

        public AccessController GetCtrlrById(int id)
        {
            return _context.AccessControllers.FirstOrDefault(item => item.CtrlrId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCtrlr(AccessController item)
        {
            AccessController item1 = _context.AccessControllers.Single(a => a.CtrlrId == item.CtrlrId);
            item1=item;
            _context.TableUpdates.FirstOrDefault(x=>x.TableId==2).LastUpdate = DateTime.Now;
        }
    }
}