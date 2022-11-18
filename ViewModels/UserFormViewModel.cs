using MVVMDemo.Commands;
using MVVMDemo.Models;
using MVVMDemo.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.ViewModels
{
    public class UserFormViewModel : ViewModelBase
    {
        public UserFormViewModel(ICommand submitCommand, ICommand cancelCommand , User user= null )
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
            if(user != null )
            {
                Name= user.Name;
                Active = user.isActive;
                Working = user.isWorking;
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(CanSubmit));

            }
        }

        private bool _isActive = false;

        public bool Active
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(Active));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private bool _isWorking = false;

        public bool Working
        {
            get { return _isWorking; }
            set
            {
                _isWorking = value;
                OnPropertyChanged(nameof(Working));

            }
        }
        public bool CanSubmit => isValidName();

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private bool isValidName()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                if(Name.Length >= 3)
                {
                    return true;
                }
            }
            return false;
        }



    }
}
