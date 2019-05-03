using AutoMapper;
using ConsultingManager.Dto;
using ConsultingManager.Infra.Database.Models;

namespace ConsultingManager.Domain
{
    public class InfraToDto : Profile
    {
        public InfraToDto()
        {
            CreateMap<PlatformPoco, PlatformDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<CustomerPoco, CustomerDto>()
                //.ForMember(o => o.Platform, src => src.MapFrom(u => u.Platform))
                .ForAllOtherMembers(opts => opts.MapAtRuntime());
        }
    }
}
