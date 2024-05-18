using ApplicationLayer.Controllers;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Viewmodels
{
    public class MainViewModel : INotifyPropertyChanged
    {
            private readonly HorseController _horseController;
            private ObservableCollection<Horse> horses {  get; set; }

            public event PropertyChangedEventHandler PropertyChanged;

        private Horse _selectedHorse;

        public MainViewModel()
            {
                _horseController = new HorseController();
                LoadHorses();

            }

            public ObservableCollection<Horse> Horses
            {
                get => horses;
                set
                {
                    horses = value;
                    OnPropertyChanged(nameof(Horses));
                }
            }

            public Horse SelectedHorse
            {
                get => _selectedHorse;
                set
                {
                    _selectedHorse = value;
                    OnPropertyChanged(nameof(SelectedHorse));
                }
            }

        private void LoadHorses()
            {
                Horses = new ObservableCollection<Horse>(_horseController.GetAll());
            }

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    }
}
