using Stable_management_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stable_management_system.Commands
{
    class DeleteHorseOwnerCommand: ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            bool result = true;
            if (parameter is HorseOwnerMainViewModel mvm)
            {
                if (mvm.SelectedHorseOwner == null)
                {
                    result = false;
                }
            }
            return result;
        }

        public void Execute(object? parameter)
        {
            if (parameter is HorseOwnerMainViewModel mvm)
            {
                int id = mvm.SelectedHorseOwner.Id;
                mvm.RemoveSelectedHorseOwner(id);
            }
        }
    }
}
