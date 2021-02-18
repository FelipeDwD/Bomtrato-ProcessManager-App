using AutoMapper;
using Bomtrato.ProcessManager.App.WebAPI.Application.ViewModels;
using Bomtrato.ProcessManager.App.WebAPI.Domain.Domain;

namespace Bomtrato.ProcessManager.App.WebAPI.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ApproverDomain, ApproverViewModel>().ReverseMap();
            CreateMap<OfficeDomain, OfficeViewModel>().ReverseMap();
            CreateMap<ProcessDomain, ProcessViewModel>().ReverseMap();            
        }
    }
}