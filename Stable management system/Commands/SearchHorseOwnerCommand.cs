using Stable_management_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stable_management_system.Commands
{
    class SearchHorseOwnerCommand: ICommand
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
                string searchCriteria = mvm.SearchForHorseOwner;
                if (String.IsNullOrEmpty(searchCriteria))
                {
                    mvm.LoadHorseOwners();
                }
                else if (String.IsNullOrEmpty(searchCriteria) == false)
                {
                    mvm.LoadHorseOwners(searchCriteria);
                }
            }
        }
    }
}
