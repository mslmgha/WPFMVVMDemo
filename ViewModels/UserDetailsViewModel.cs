using MVVMDemo.Models;
using MVVMDemo.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.ViewModels
{
    public class UserDetailsViewModel : ViewModelBase
    {
        private readonly SelectedUserStore _selectedUserStore;
        private User _selectedUser=> _selectedUserStore.SelectedUser;

        public bool isUserSelected=> _selectedUser != null;

        public string Name => _selectedUser?.Name?? "Unknown";
        public string IsActive => (_selectedUser?.isActive?? false) ? "Yes" : "No";
        public string IsWorking => (_selectedUser?.isWorking ?? false) ? "Yes" : "No";

        public UserDetailsViewModel(SelectedUserStore selectedUserStore) {

            _selectedUserStore=selectedUserStore;

            _selectedUserStore.selectedUserChange += _selectedUserStore_selectedUserChange;

        }
        protected override void Despose()
        {
            _selectedUserStore.selectedUserChange -= _selectedUserStore_selectedUserChange;
            base.Despose();
        }

        private void _selectedUserStore_selectedUserChange()
        {
            OnPropertyChanged(nameof(isUserSelected));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(IsActive));
            OnPropertyChanged(nameof(IsWorking));
        }
    }
}
