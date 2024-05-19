using Kallesstaldsystem.Model;
using Stable_management_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stable_management_system.Commands
{
    internal class CreateHorseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.AddHorse(new Horse("not specified", "not specified", Horse.EquineType.Unknown, Horse.Gender.Unknown));
            }
        }
    }
}
