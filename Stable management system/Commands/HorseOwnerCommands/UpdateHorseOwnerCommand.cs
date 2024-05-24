using Stable_management_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stable_management_system.Commands.HorseOwnerCommands
{
    class UpdateHorseOwnerCommand:ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is HorseOwnerMainViewModel mvm)
            {
                mvm.Update(mvm.SelectedHorseOwner);
            }
        }
    }
}

