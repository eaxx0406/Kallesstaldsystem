using Stable_management_system.ViewModels;
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

namespace Stable_management_system.Pages.HorseOwnerOverview
{
    /// <summary>
    /// Interaction logic for EditHorseOwnerTab.xaml
    /// </summary>
    public partial class EditHorseOwnerTab : Page
    {
        Frame Frame { get; set; }
        HorseOwnerMainViewModel HOvm { get; set; }

        public EditHorseOwnerTab(HorseOwnerMainViewModel hOvm, Frame frame)
        {
            InitializeComponent();
            DataContext = hOvm;
            HOvm = hOvm;
            Frame = frame;
        }

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame.Content = new HorseOwnerInfoTab(HOvm);
        //}
    }
}
