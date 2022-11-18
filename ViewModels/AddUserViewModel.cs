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
    public class AddUserViewModel:ViewModelBase
    {
        public UserFormViewModel UserFormViewModel { get; }

        public AddUserViewModel(ModelNavigationStore modelNavigationStore,UserStore userStore) {
            ICommand submitUserComand = new SubmitUserCommand(this,userStore,modelNavigationStore);
            ICommand cancelComand = new CloseAddUserCommand(modelNavigationStore);
            UserFormViewModel = new UserFormViewModel(submitUserComand, cancelComand);
        }   
    }
}
