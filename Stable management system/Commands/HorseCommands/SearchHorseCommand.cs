using Stable_management_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kallesstaldsystem.Model;

namespace Stable_management_system.Commands
{
    internal class SearchHorseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is HorseMainViewModel mvm)
            {
                string searchCriteria = mvm.SearchForHorse;
               if (String.IsNullOrEmpty(searchCriteria)) 
                {
                    mvm.LoadHorses();
                }
               else if (String.IsNullOrEmpty(searchCriteria) == false ) 
                {
                    mvm.LoadHorses(searchCriteria);
                }
            }
        }
    }
}
