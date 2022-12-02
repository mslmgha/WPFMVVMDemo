using MVVMDemo.Stores;

namespace MVVMDemo.Commands
{
    public class CloseAddUserCommand : BaseCommand
    {
        private readonly ModelNavigationStore _modelNavigationStore;

        public CloseAddUserCommand (ModelNavigationStore modelNavigationStore)
        {
            this._modelNavigationStore = modelNavigationStore;

        }
        public override void Execute(object? parameter)
        {
            _modelNavigationStore.Close();
        }
    }
}
