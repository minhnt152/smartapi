using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class AccessCtrlrProfile:Profile
    {
        public AccessCtrlrProfile()
        {
            CreateMap<AccessControllerBrandSystem,AccessCtrlrBrandSysReadDto>();
            CreateMap<AccessControllerModel,AccessCtrlrModelReadDto>();

            CreateMap<AccessControllerNetwork,AccessCtrlrNetworkReadDto>();
            CreateMap<AccessCtrlrNetworkUpdateDto,AccessControllerNetwork>();
            CreateMap<AccessCtrlrNetworkInsertDto,AccessControllerNetwork>();      

            CreateMap<AccessControllerModel,AccessCtrlrModelReadDto>();   

            CreateMap<AccessController,AccessCtrlrReadDto>();
            CreateMap<AccessCtrlrUpdateDto,AccessController>();
            CreateMap<AccessCtrlrInsertDto,AccessController>();

        }
        
    }    

}