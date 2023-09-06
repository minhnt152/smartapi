using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface IAccessCtrlrModelRepo{
        IEnumerable<AccessControllerModel> GetAllCtrlrModels();
        AccessControllerModel GetCtrlrModelById(int id);

        bool SaveChanges();
    
    }
}