using ConsultingManager.Dto;
using System.Threading.Tasks;

namespace ConsultingManager.Domain.Repository
{
    public interface IUserRepository
    {
        Task<UserDto> Add(UserDto userDto);
        Task<UserDto> Authenticate(string email, string password);
    }
}