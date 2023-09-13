using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;
using smartapi.Models;

namespace smartapi.Data
{
    public class SqlSettingRepo : ISettingRepo
    {
        private readonly SmAccessParkingContext _context;
        public SqlSettingRepo(SmAccessParkingContext context){
            _context = context;
        }

        public void CreateSetting(AccessSetting item)
        {
            if(item==null){
                 throw new ArgumentNullException(nameof(item));
            }
            _context.AccessSettings.Add(item);
        }

        public void DelSetting(AccessSetting item)
        {
            if(item==null){
                throw new ArgumentNullException(nameof(item));
            }

            _context.AccessSettings.Remove(item);
        }

        public IEnumerable<AccessSetting> GetAllSettings()
        {
            return _context.AccessSettings.ToArray();
        }

        public AccessSetting GetSettingById(int id)
        {
            return _context.AccessSettings.FirstOrDefault(item => item.SettingId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSetting(AccessSetting item)
        {
            AccessSetting item1 = _context.AccessSettings.Single(a => a.SettingId == item.SettingId);
            item1=item;
        }
    }
}