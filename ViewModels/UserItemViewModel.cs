using DocumentFormat.OpenXml.Spreadsheet;
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
    public class UserItemViewModel:ViewModelBase
    {
        public  User User { get; private set; }
        public string Name => User?.Name ?? "Unknown";
        public ICommand EditCommand { get;  }

        public ICommand DeleteCommand { get; }

        public UserItemViewModel(User user, UserStore userStore, ModelNavigationStore modelNavigationStore) {

          this.User = user;
          EditCommand = new OpenEditUserCommand(this, modelNavigationStore, userStore);
          DeleteCommand = new DeleteUserCommand(this, modelNavigationStore, userStore);

        }
        public void Upadte(User obj)
        {
            this.User = obj;
            OnPropertyChanged(nameof(Name));
        }
    }
}
