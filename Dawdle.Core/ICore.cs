using Dawdle.Database.Models;
using System.Threading.Tasks;

namespace Dawdle.Core
{
    public interface ICore
    {
        Task<User> GetUser(string userName);
    }
}