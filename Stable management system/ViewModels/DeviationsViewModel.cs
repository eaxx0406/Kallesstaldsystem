using Stable_management_system.Commands;
using ApplicationLayer;
using ApplicationLayer.Controllers;
using Kallesstaldsystem.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;

namespace Stable_management_system.ViewModels
{
    class DeviationsViewModel
    {
        private DeviationController _deviationController { get; set; }
        public ObservableCollection<Deviation> Deviations { get; set; } = new ObservableCollection<Deviation>();

        public DeviationsViewModel() 
        {
            _deviationController = new DeviationController();
            LoadDeviations();
        }

        public void LoadDeviations()
        {
            Deviations.Clear();
            List<Deviation> TempDeviation = _deviationController.GetAll();
            foreach (Deviation deviation in TempDeviation)
            {
                Deviations.Add(deviation);
            }
        }
    }
}
