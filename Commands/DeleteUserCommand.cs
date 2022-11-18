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
    public class DeleteUserCommand : AsyncBaseCommand
    {
        private readonly UserItemViewModel _userItemViewModel;
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly UserStore _userStore;

        public DeleteUserCommand(UserItemViewModel userItemViewModel, ModelNavigationStore modelNavigationStore, UserStore userStore)
        {
            this._userItemViewModel = userItemViewModel;
            _modelNavigationStore = modelNavigationStore;
            this._userStore = userStore;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            _userStore.Delete(_userItemViewModel.User.Id);
        }
    }
}
