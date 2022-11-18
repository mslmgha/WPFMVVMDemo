using MVVMDemo.Models;
using MVVMDemo.Stores;
using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMDemo.Commands
{
    public class OpenEditUserCommand : BaseCommand
    {
        private readonly UserItemViewModel _userItemViewModel;
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly UserStore _userStore;
        private readonly User _selectedUserStore;

        public OpenEditUserCommand(UserItemViewModel userItemViewModel,ModelNavigationStore modelNavigationStores, UserStore userStore)
        {
            this._userItemViewModel = userItemViewModel;
            this._modelNavigationStore = modelNavigationStores;
            this._userStore = userStore;
        }

   

        public override void Execute(object? parameter)
        {
            EditUserViewModel editUserViewModel = new EditUserViewModel(_modelNavigationStore, _userItemViewModel.User, _userStore);
            _modelNavigationStore.CurrentViewModel = editUserViewModel;
        }
    }
}
