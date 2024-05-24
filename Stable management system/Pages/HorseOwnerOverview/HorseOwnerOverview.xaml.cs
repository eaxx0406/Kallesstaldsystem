using Stable_management_system.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Stable_management_system.Pages.HorseOwnerOverview
{
    /// <summary>
    /// Interaction logic for HorseOwnerOverview.xaml
    /// </summary>
    public partial class HorseOwnerOverview : Page
    {
        HorseOwnerMainViewModel mvm = new HorseOwnerMainViewModel();
        public HorseOwnerOverview()
        {
            InitializeComponent();
            DataContext = mvm;
            HorseOwnerFrame.Content = new HorseOwnerInfoTab(mvm);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HorseOwnerFrame.Content = new EditHorseOwnerTab(mvm, HorseOwnerFrame);

        }
    }
}
