using MVVMDemo.Commands;
using MVVMDemo.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        public UsersListingViewModel UsersListingViewModel { get; }
        public UserDetailsViewModel UserDetailsViewModel { get; }
        public ICommand addUserCommand { get; }

        public HomeViewModel(SelectedUserStore selectedUserStore,ModelNavigationStore modelNavigationStore,UserStore userStore)
        {
            UserDetailsViewModel= new UserDetailsViewModel(selectedUserStore);
            UsersListingViewModel= new UsersListingViewModel(userStore, selectedUserStore, modelNavigationStore);
            addUserCommand = new AddUserCommand(modelNavigationStore, userStore);
        }
    }
}
