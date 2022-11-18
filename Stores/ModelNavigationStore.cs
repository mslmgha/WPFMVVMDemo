using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Stores
{
    public class ModelNavigationStore
    {
		private ViewModelBase _currentViewModel;

		public ViewModelBase CurrentViewModel
		{
			get { return _currentViewModel; }
			set { 

				_currentViewModel = value;
				viewModelChanged?.Invoke();
			}
		}

        public bool IsOpen => _currentViewModel != null;

        public event Action viewModelChanged;

        internal void Close()
        {
            CurrentViewModel = null;
        }
    }
}
