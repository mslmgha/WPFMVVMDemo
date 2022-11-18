using DocumentFormat.OpenXml.Spreadsheet;
using MVVMDemo.Commands;
using MVVMDemo.Models;
using MVVMDemo.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{
    public class UsersListingViewModel: ViewModelBase
    {
        private readonly ObservableCollection<UserItemViewModel> _userList;
        private readonly UserStore _userStore;
        private SelectedUserStore _selectedUserStore;
        private readonly ModelNavigationStore modelNavigationStore;
        private UserItemViewModel _selectedUserItemViewModel;

        public UserItemViewModel SelectedUserItemViewModel
        {
            get { 
                return _selectedUserItemViewModel; 
            }
            set {
                _selectedUserItemViewModel = value; 
                _selectedUserStore.SelectedUser = SelectedUserItemViewModel?.User;
                OnPropertyChanged(nameof(SelectedUserItemViewModel));
            }
        }

        public IEnumerable<UserItemViewModel> UserList=> _userList;

        public UsersListingViewModel(UserStore userStore, SelectedUserStore selectedUserStore, ModelNavigationStore modelNavigationStore) {
            _userStore = userStore;
            _selectedUserStore = selectedUserStore;
            this.modelNavigationStore = modelNavigationStore;
            _userStore.UserAdded += _userStore_UserAdded;
            _userStore.UserUpdated += _userStore_UserUpadted;
            _userStore.UserDeleted += _userStore_UserDeleted;
            _userList = new ObservableCollection<UserItemViewModel>();
          
        }

        private void _userStore_UserDeleted(Guid obj)
        {
            UserItemViewModel currentUser = _userList.FirstOrDefault(x => x.User.Id == obj);
            if (currentUser != null)
            {
                _userList.Remove(currentUser);
                
            }
        }

        private void _userStore_UserUpadted(User obj)
        {
            UserItemViewModel currentUser= _userList.FirstOrDefault(x=>x.User.Id==obj.Id);
            if(currentUser!=null)
            {
                currentUser.Upadte(obj);
            }
        }

        protected override void Despose()
        {
            _userStore.UserAdded -= _userStore_UserAdded;
            _userStore.UserUpdated -= _userStore_UserUpadted;
            _userStore.UserDeleted -= _userStore_UserDeleted;
            base.Despose();
        }

        private void _userStore_UserAdded(User obj)
        {
            addUser(obj);
        }

        private void addUser(User user)
        {
            _userList.Add(new UserItemViewModel(user, _userStore ,modelNavigationStore));
        }

    }
}
