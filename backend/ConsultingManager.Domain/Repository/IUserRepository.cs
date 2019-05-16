using System.Threading.Tasks;
using ConsultingManager.Dto;

namespace ConsultingManager.Domain.Repository
{
    public interface IUserRepository
    {
        Task<UserDto> Authenticate(string email, string password);
    }
}