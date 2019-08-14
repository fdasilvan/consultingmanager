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
            CreateMap<ModelProcessPoco, ModelProcessDto>().ForAllMembers(opts => opts.MapAtRuntime());
            CreateMap<ModelProcessDto, ModelProcessPoco>().ForAllMembers(opts => opts.MapAtRuntime());
            CreateMap<ModelStepDto, ModelStepPoco>().ForAllMembers(opts => opts.MapAtRuntime());
            CreateMap<ModelStepPoco, ModelStepDto>().ForAllMembers(opts => opts.MapAtRuntime());
            CreateMap<ModelTaskDto, ModelTaskPoco>().ForAllMembers(opts => opts.MapAtRuntime());
            CreateMap<ModelTaskPoco, ModelTaskDto>().ForAllMembers(opts => opts.MapAtRuntime());
            CreateMap<CustomerPoco, CustomerDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<CustomerDto, CustomerPoco>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<CustomerProcessPoco, CustomerProcessDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<CustomerMeetingDto, CustomerMeetingPoco>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<CustomerMeetingPoco, CustomerMeetingDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<CustomerStepPoco, CustomerStepDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<CustomerTaskPoco, CustomerTaskDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<UserPoco, UserDto>().ForMember(o => o.Password, src => src.Ignore()).ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<UserDto, UserPoco>().ForAllOtherMembers(opts => opts.MapAtRuntime());
            CreateMap<UserTypePoco, UserTypeDto>().ForAllOtherMembers(opts => opts.MapAtRuntime());
        }
    }
}
