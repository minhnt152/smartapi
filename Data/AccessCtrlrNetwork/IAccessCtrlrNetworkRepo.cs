using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface IAccessCtrlrNetworkRepo{
        IEnumerable<AccessControllerNetwork> GetAllCtrlrNetworks();
        AccessControllerNetwork GetCtrlrNetworkById(int id);
        void CreateNetwork(AccessControllerNetwork item);
        void UpdateNetwork(AccessControllerNetwork item);
        void DelNetwork(AccessControllerNetwork item);
        bool SaveChanges();
    
    }
}