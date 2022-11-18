using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Stores
{
    public class SelectedUserStore
    {
        private readonly UserStore _store;
        private User _user;
        public User SelectedUser
        {
            get { return _user; }
            set
            {
                if (value == _user)
                    return;
                _user = value;
                selectedUserChange?.Invoke();
            }
        }
        public SelectedUserStore(UserStore store)
        {
            _store = store;
            _store.UserUpdated += _store_UserUpdated;

        }

        private void _store_UserUpdated(User obj)
        {
           this._user= obj;
           selectedUserChange?.Invoke();
        }

        public event Action selectedUserChange;
    }
}
