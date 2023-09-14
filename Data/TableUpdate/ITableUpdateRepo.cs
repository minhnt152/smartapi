using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface ITableUpdateRepo{
        IEnumerable<TableUpdate> GetAllTableUpdate();
        TableUpdate GetTableUpdateById(int id);

        bool SaveChanges();
    
    }
}