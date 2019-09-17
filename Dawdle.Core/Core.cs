using Dawdle.Database;
using Dawdle.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Dawdle.Core
{
    public class Core : ICore
    {
        private DBContex _dbContext;
        public Core(DBContex dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<User> GetUser(string userName)
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.FirstOrDefault<User>(u => u.Username == userName);
        }
    }
}
