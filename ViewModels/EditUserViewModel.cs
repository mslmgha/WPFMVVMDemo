using MVVMDemo.Commands;
using MVVMDemo.Models;
using MVVMDemo.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{
    public class EditUserViewModel:ViewModelBase
    {
        public UserFormViewModel UserFormViewModel { get; }

        public EditUserViewModel(ModelNavigationStore modelNavigationStore, User selectedUser,UserStore userStore)
        {
            ICommand submitUserComand = new SubmitEditedUserCommand(this,userStore,modelNavigationStore, selectedUser);
            ICommand cancelComand = new CloseAddUserCommand(modelNavigationStore);
            UserFormViewModel = new UserFormViewModel(submitUserComand, cancelComand, selectedUser);

        }
    }
}
