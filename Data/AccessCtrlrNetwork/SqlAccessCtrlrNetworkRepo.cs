using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlAccessCtrlrNetworkRepo : IAccessCtrlrNetworkRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlAccessCtrlrNetworkRepo(SmAccessParkingContext context){
            _context = context;
        }

        public void CreateNetwork(AccessControllerNetwork item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }
            _context.AccessControllerNetworks.Add(item);
            _context.TableUpdates.FirstOrDefault(x=>x.TableId==1).LastUpdate = DateTime.Now;
        }

        public void DelNetwork(AccessControllerNetwork item)
        {
            if(item==null){
                throw new ArgumentNullException(nameof(item));
            }

            _context.AccessControllerNetworks.Remove(item);
            _context.TableUpdates.FirstOrDefault(x=>x.TableId==1).LastUpdate = DateTime.Now;
        }

        public IEnumerable<AccessControllerNetwork> GetAllCtrlrNetworks()
        {
            return _context.AccessControllerNetworks.ToArray();
        }

        public AccessControllerNetwork GetCtrlrNetworkById(int id)
        {
             return _context.AccessControllerNetworks.FirstOrDefault(item => item.NetworkId == id);
        }

        public bool SaveChanges()
        {
             return (_context.SaveChanges() >= 0);
        }

        public void UpdateNetwork(AccessControllerNetwork item)
        {
            AccessControllerNetwork item1 = _context.AccessControllerNetworks.Single(a => a.NetworkId == item.NetworkId);
            if(item1==null){
                throw new ArgumentNullException(nameof(item1));
            }

            item1 = item;
            _context.TableUpdates.FirstOrDefault(x=>x.TableId==1).LastUpdate = DateTime.Now;
        }
    }
}