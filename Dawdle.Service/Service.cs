using AgileObjects.AgileMapper;
using Dawdle.Core;
using Dawdle.Core.DTO;
using System.Threading.Tasks;

namespace Dawdle.Service
{
    public class Service : IService
    {
        private ICore _core;
        public Service(ICore core)
        {
            _core = core;
        }

        public async Task<UserDTO> GetUser(string userName)
        {
            var user = await _core.GetUser(userName);
            return user != null ? Mapper.Map(user).ToANew<UserDTO>() : null;
        }
    }
}
