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
    public class HorseMainViewModel : INotifyPropertyChanged
    {
        private HorseController _horseController;
        private Horse _selectedHorse;
        private FeedingScheduel _selectedHorsesFeedingScheduel;
        private string _selectedHorsePaddockName = "Ikke sat";
        private string _selectedHorseOwnerPhone = "Ikke Sat";
        private string _selectedHorseOwnerName = "Ikke Sat";
        private string _searchForHorse;
        private ICollectionView _horsesView;
        public ICollectionView HorsesView
        {
            get { return _horsesView; }
            set
            {
                if (_horsesView != value)
                {
                    _horsesView = value;
                    OnPropertyChanged(nameof(HorsesView));
                }
            }
        }

        public ObservableCollection<Horse> Horses { get; set; } = new ObservableCollection<Horse>();

        public Horse SelectedHorse
        {
            get => _selectedHorse;
            set
            {
                if (_selectedHorse != value)
                {
                    _selectedHorse = value;
                    OnPropertyChanged(nameof(SelectedHorse));
                    UpdateSelectedHorseDetails();
                }
            }
        }

        public FeedingScheduel SelectedHorsesFeedingScheduel
        {
            get => _selectedHorsesFeedingScheduel;
            set
            {
                if (_selectedHorsesFeedingScheduel != value)
                {
                    _selectedHorsesFeedingScheduel = value;
                    OnPropertyChanged(nameof(SelectedHorsesFeedingScheduel));
                }
            }
        }

        public string SelectedHorsePaddockName
        {
            get => _selectedHorsePaddockName;
            set
            {
                if (_selectedHorsePaddockName != value)
                {
                    _selectedHorsePaddockName = value;
                    OnPropertyChanged(nameof(SelectedHorsePaddockName));
                }
            }
        }

        public string SelectedHorseOwnerPhone
        {
            get => _selectedHorseOwnerPhone;
            set
            {
                if (_selectedHorseOwnerPhone != value)
                {
                    _selectedHorseOwnerPhone = value;
                    OnPropertyChanged(nameof(SelectedHorseOwnerPhone));
                }
            }
        }

        public string SelectedHorseOwnerName
        {
            get => _selectedHorseOwnerName;
            set
            {
                if (_selectedHorseOwnerName != value)
                {
                    _selectedHorseOwnerName = value;
                    OnPropertyChanged(nameof(SelectedHorseOwnerName));
                }
            }
        }

        public string SearchForHorse
        {
            get => _searchForHorse;
            set
            {
                if (_searchForHorse != value)
                {
                    _searchForHorse = value;
                    OnPropertyChanged(nameof(SearchForHorse));
                }
            }
        }

        public ICommand CreateHorseCMD { get; set; }
        public ICommand DeleteHorseCMD { get; set; }
        public ICommand SearchHorseCMD { get; set; }
        public ICommand UpdateHorseCMD { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public HorseMainViewModel()
        {
            _horseController = new HorseController();
            CreateHorseCMD = new CreateHorseCommand();
            DeleteHorseCMD = new DeleteHorseCommand();
            SearchHorseCMD = new SearchHorseCommand();
            UpdateHorseCMD = new UpdateHorseCommand();
            LoadHorses();

            HorsesView = CollectionViewSource.GetDefaultView(Horses);
            HorsesView.SortDescriptions.Add(new SortDescription(nameof(Horse.Name), ListSortDirection.Ascending));

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateSelectedHorseDetails()
        {
            if (SelectedHorse != null)
            {
                GetSelectedFeedingScheduel();
                GetPaddockName();
                GetOwnerInfo();
            }
            else
            {
                SelectedHorsesFeedingScheduel = null;
                SelectedHorsePaddockName = "Ikke sat";
                SelectedHorseOwnerName = "Ikke Sat";
                SelectedHorseOwnerPhone = "Ikke Sat";
            }
        }

        public void LoadHorses()
        {
            Horses.Clear();
            List<Horse> TempHorses = _horseController.GetAll();
            foreach (Horse horse in TempHorses)
            {
                Horses.Add(horse);
            }
        }

        public void LoadHorses(string searchFor)
        {
            Horses.Clear();
            List<Horse> TempHorses = _horseController.GetAll();
            foreach (Horse horse in TempHorses)
            {
                string HorsenameAllLower = horse.Name.ToLower();
                if (HorsenameAllLower.Contains(searchFor.ToLower()))
                {
                    Horses.Add(horse);
                }
            }
        }

        public void Update(Horse horse)
        {
            _horseController.Update(horse);
        }

        public void AddHorse(Horse horse)
        {
            _horseController.Add(horse);
            Horses.Add(horse);
        }

        public void RemoveSelectedHorse(int id)
        {
            _horseController.Remove(id);
            Horses.Remove(SelectedHorse);
        }

        public void GetSelectedFeedingScheduel()
        {
            FeedingScheduelController feedingScheduelController = new FeedingScheduelController();
            List<FeedingScheduel> allFeedingschduels = feedingScheduelController.GetAll();
            foreach (FeedingScheduel feedingscheduel in allFeedingschduels)
            {
                if (feedingscheduel.Id == SelectedHorse.FeedingScheduelId)
                {
                    SelectedHorsesFeedingScheduel = feedingscheduel;
                    break;
                }
            }
        }

        public void GetPaddockName()
        {
            PaddockController paddockController = new PaddockController();
            List<Paddock> allPaddocks = paddockController.GetAll();
            foreach (Paddock paddock in allPaddocks)
            {
                if (paddock.Id == SelectedHorse.PaddockId)
                {
                    SelectedHorsePaddockName = paddock.Name;
                    break;
                }
            }
        }

        public void GetOwnerInfo()
        {
            HorseOwnerController horseOwnerController = new HorseOwnerController();
            List<HorseOwner> allHorseOwners = horseOwnerController.GetAll();
            foreach (HorseOwner horseOwner in allHorseOwners)
            {
                if (horseOwner.Id == SelectedHorse.OwnerId)
                {
                    SelectedHorseOwnerName = horseOwner.Name;
                    SelectedHorseOwnerPhone = horseOwner.Phone;
                    break;
                }
            }
        }
    }
}
