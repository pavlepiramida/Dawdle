using Dawdle.Core.DTO;
using System.Threading.Tasks;

namespace Dawdle.Service
{
    public interface IService
    {
        Task<UserDTO> GetUser(string userName);
    }
}