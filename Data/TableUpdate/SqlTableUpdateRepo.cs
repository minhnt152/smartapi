using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlTableUpdateRepo : ITableUpdateRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlTableUpdateRepo(SmAccessParkingContext context){
            _context = context;
        }

        public IEnumerable<TableUpdate> GetAllTableUpdate()
        {
            return _context.TableUpdates.ToArray();
        }

        public TableUpdate GetTableUpdateById(int id)
        {
            return _context.TableUpdates.FirstOrDefault(x=>x.TableId==id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}