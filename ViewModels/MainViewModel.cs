using MVVMDemo.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private ModelNavigationStore _modelNavigationStore;

        public ViewModelBase CurentViewModel => _modelNavigationStore.CurrentViewModel;

        public bool IsOpen => _modelNavigationStore.IsOpen;
        public HomeViewModel HomeViewModel { get; }

        public MainViewModel(ModelNavigationStore modelNavigationStore, HomeViewModel homeViewModel)
        {
            _modelNavigationStore = modelNavigationStore;
            HomeViewModel = homeViewModel;
            _modelNavigationStore.viewModelChanged += ModelNavigationStore_viewModelChanged;
        }

        private void ModelNavigationStore_viewModelChanged()
        {
            OnPropertyChanged(nameof(CurentViewModel));
            OnPropertyChanged(nameof(IsOpen));
        }

        protected override void Despose()
        {
            _modelNavigationStore.viewModelChanged -= ModelNavigationStore_viewModelChanged;
            base.Despose();
        }
    }
}
