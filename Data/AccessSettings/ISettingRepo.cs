using System;
using System.Collections.Generic;
using smartapi.Models;

namespace smartapi.Data{
    public interface ISettingRepo{
        IEnumerable<AccessSetting> GetAllSettings();
        AccessSetting GetSettingById(int id);
        void CreateSetting(AccessSetting item);
        void UpdateSetting(AccessSetting item);
        void DelSetting(AccessSetting item);
        bool SaveChanges();    
    }
}