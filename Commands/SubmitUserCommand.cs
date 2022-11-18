using MVVMDemo.Models;
using MVVMDemo.Stores;
using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Commands
{
    public class SubmitUserCommand : AsyncBaseCommand
    {
        private readonly AddUserViewModel _addUserViewModel;
        private readonly UserStore _userStore;
        private readonly ModelNavigationStore _modelNavigationStore;

        public SubmitUserCommand(AddUserViewModel addUserViewModel, UserStore userStore, ModelNavigationStore modelNavigationStore)
        {
            this._addUserViewModel = addUserViewModel;
            this._userStore = userStore;
            this._modelNavigationStore = modelNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            User user = new User(Guid.NewGuid(),_addUserViewModel.UserFormViewModel.Name, _addUserViewModel.UserFormViewModel.Active, _addUserViewModel.UserFormViewModel.Working);
            await _userStore.Add(user);
            _modelNavigationStore.Close();
        }
    }
}
