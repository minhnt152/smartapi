using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface IAccessCtrlrBrandSysRepo{
        IEnumerable<AccessControllerBrandSystem> GetAllCtrlrBrandSystems();
        AccessControllerBrandSystem GetCtrlrBrandSystemById(int id);

        bool SaveChanges();
    
    }
}