using MVVMDemo.Models;
using MVVMDemo.Stores;
using MVVMDemo.ViewModels;
using System.Threading.Tasks;

namespace MVVMDemo.Commands
{
    public class SubmitEditedUserCommand:AsyncBaseCommand
    {
        private readonly EditUserViewModel _editUserViewModel;
        private readonly UserStore _userStore;
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly User _currentUser;
        private readonly User _user;

        public SubmitEditedUserCommand(EditUserViewModel editUserViewModel, UserStore userStore, ModelNavigationStore modelNavigationStore, User currentUser)
        {
            this._editUserViewModel = editUserViewModel;
            this._userStore = userStore;
            this._modelNavigationStore = modelNavigationStore;
            this._currentUser = currentUser;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            User user = new User(_currentUser.Id, _editUserViewModel.UserFormViewModel.Name, _editUserViewModel.UserFormViewModel.Active, _editUserViewModel.UserFormViewModel.Working);
            await _userStore.Update(user);
            _modelNavigationStore.Close();
        }
    }
}
