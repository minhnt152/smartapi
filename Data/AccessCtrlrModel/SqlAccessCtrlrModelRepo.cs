using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlAccessCtrlrModelRepo : IAccessCtrlrModelRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlAccessCtrlrModelRepo(SmAccessParkingContext context){
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<AccessControllerModel> GetAllCtrlrModels()
        {
            return _context.AccessControllerModels.ToArray();
        }

        public AccessControllerModel GetCtrlrModelById(int id)
        {
            return _context.AccessControllerModels.FirstOrDefault(item => item.ModelId == id);
        }

    }
}