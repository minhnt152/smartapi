using smartapi.Dtos;
using smartapi.Models;
using AutoMapper;

namespace smartapi.Profiles
{
    public class DoorProfile:Profile
    {
        public DoorProfile()
        {
            CreateMap<Door,DoorReadDto>()
            .ForMember(att => att.ControllerId, act => act.MapFrom(src => src.CnctCtrlrId))
            .ForMember(att => att.Description, act => act.MapFrom(src => src.Descr))
            .ForMember(att => att.PEntranceReader, act => act.MapFrom(src => src.PInput))
            .ForMember(att => att.PExitReader, act => act.MapFrom(src => src.POutput))
            .ForMember(att => att.PRexButton, act => act.MapFrom(src => src.PButtonStt))
            .ForMember(att => att.PDoor1Status, act => act.MapFrom(src => src.PDoorStt))
            .ForMember(att => att.PDoor2Status, act => act.MapFrom(src => src.PDoor2Stt))
            .ForMember(att => att.PLock, act => act.MapFrom(src => src.PLockCtrl));

            CreateMap<DoorUpdateDto,Door>()
            .ForMember(att => att.CnctCtrlrId, act => act.MapFrom(src => src.ControllerId))
            .ForMember(att => att.Descr, act => act.MapFrom(src => src.Description))
            .ForMember(att => att.PInput, act => act.MapFrom(src => src.PEntranceReader))
            .ForMember(att => att.POutput, act => act.MapFrom(src => src.PExitReader))
            .ForMember(att => att.PButtonStt, act => act.MapFrom(src => src.PRexButton))
            .ForMember(att => att.PDoorStt, act => act.MapFrom(src => src.PDoor1Status))
            .ForMember(att => att.PDoor2Stt, act => act.MapFrom(src => src.PDoor2Status))
            .ForMember(att => att.PLockCtrl, act => act.MapFrom(src => src.PLock));

            CreateMap<DoorInsertDto,Door>()
            .ForMember(att => att.CnctCtrlrId, act => act.MapFrom(src => src.ControllerId))
            .ForMember(att => att.Descr, act => act.MapFrom(src => src.Description))
            .ForMember(att => att.PInput, act => act.MapFrom(src => src.PEntranceReader))
            .ForMember(att => att.POutput, act => act.MapFrom(src => src.PExitReader))
            .ForMember(att => att.PButtonStt, act => act.MapFrom(src => src.PRexButton))
            .ForMember(att => att.PDoorStt, act => act.MapFrom(src => src.PDoor1Status))
            .ForMember(att => att.PDoor2Stt, act => act.MapFrom(src => src.PDoor2Status))
            .ForMember(att => att.PLockCtrl, act => act.MapFrom(src => src.PLock));        
        }
        
    }    

}