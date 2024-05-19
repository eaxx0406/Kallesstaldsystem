using Stable_management_system.ViewModels;
using System.Windows.Input;

namespace Stable_management_system.Commands
{
    class DeleteHorseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            bool result = true;
            if (parameter is MainViewModel mvm)
            {
                if (mvm.SelectedHorse == null)
                {
                    result = false;
                }
            }
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                int id = mvm.SelectedHorse.Id;
                mvm.RemoveSelectedHorse(id);
            }
        }
    }
}
