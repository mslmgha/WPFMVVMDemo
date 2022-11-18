using MVVMDemo.Stores;
using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.Commands
{
    public class AddUserCommand : BaseCommand
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly UserStore _userStore;

        public  AddUserCommand(ModelNavigationStore modelNavigationStore, UserStore userStore)
        {
            this._modelNavigationStore = modelNavigationStore;
            this._userStore = userStore;
        }
        public override void Execute(object? parameter)
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel(_modelNavigationStore, _userStore);
            _modelNavigationStore.CurrentViewModel= addUserViewModel;
        }

        
    }
}
