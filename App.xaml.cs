using MVVMDemo.Stores;
using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedUserStore _selectedUserStore;
        private readonly ModelNavigationStore _ModelNavigationStore;
        private readonly UserStore _userStore;

        public App()
        {
           
            _ModelNavigationStore=new ModelNavigationStore();
            _userStore= new UserStore();
            _selectedUserStore = new SelectedUserStore(_userStore);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_ModelNavigationStore, new HomeViewModel(_selectedUserStore, _ModelNavigationStore,_userStore))
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
