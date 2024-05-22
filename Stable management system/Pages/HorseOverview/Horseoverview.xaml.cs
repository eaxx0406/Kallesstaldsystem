using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Stable_management_system.ViewModels;


namespace Stable_management_system.Pages
{
    /// <summary>
    /// Interaction logic for Horseoverview.xaml
    /// </summary>
  

    public partial class Horseoverview : Page
    {

        HorseMainViewModel mvm = new HorseMainViewModel();
        public Horseoverview()
        {
            InitializeComponent();
            DataContext = mvm;
            HorseFrame.Content = new HorseInfoTab(mvm);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           HorseFrame.Content = new EditHorseTab(mvm, HorseFrame);
           
        }
        private void UpdateSelectedHorse(object sender, SelectionChangedEventArgs e)
        {
            mvm.GetSelectedFeedingScheduel();
            mvm.GetPaddockName();
            mvm.GetOwnerInfo();
        }
    }
}
