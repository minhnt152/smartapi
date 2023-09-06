using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlAccessCtrlrBrandsysRepo : IAccessCtrlrBrandSysRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlAccessCtrlrBrandsysRepo(SmAccessParkingContext context){
            _context = context;
        }

        public IEnumerable<AccessControllerBrandSystem> GetAllCtrlrBrandSystems()
        {
            return _context.AccessControllerBrandSystems.ToArray();
        }

        public AccessControllerBrandSystem GetCtrlrBrandSystemById(int id)
        {

            return _context.AccessControllerBrandSystems.FirstOrDefault(item => item.BrId == id);
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}