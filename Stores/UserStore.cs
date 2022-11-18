using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Stores
{
    public class UserStore
    {
        public event Action<User> UserAdded;
        public event Action<User> UserUpdated;
        public event Action<Guid> UserDeleted;
        public async Task Add(User user)
        {
            UserAdded?.Invoke(user);    
        }
        public async Task Update(User user)
        {
            UserUpdated?.Invoke(user);
        }
        public async Task Delete(Guid userid)
        {
            UserDeleted?.Invoke(userid);
        }
    }
}
