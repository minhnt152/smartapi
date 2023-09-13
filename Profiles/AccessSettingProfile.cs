using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class AccessSettingProfile:Profile
    {
        public AccessSettingProfile()
        {
            CreateMap<AccessSetting,SettingReadDto>();
            CreateMap<SettingInsertDto,AccessSetting>();
            CreateMap<SettingUpdateDto,AccessSetting>();      

        }
        
    }    

}