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
            CreateMap<CustomerPoco, CustomerDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<CustomerProcessPoco, CustomerProcessDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<UserPoco, UserDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<UserTypePoco, UserTypeDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
        }
    }
}
