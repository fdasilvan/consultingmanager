using ConsultingManager.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultingManager.Domain.Repository
{
    public interface IUserRepository
    {
        Task<UserDto> Add(UserDto userDto);
        Task<UserDto> Authenticate(string email, string password);
        Task<List<CustomerMeetingDto>> GetUserMeetings(Guid userId);
        Task<UserDto> GetUser(Guid userId);
        Task<bool> SaveConsultant(UserDto userDto);
    }
}