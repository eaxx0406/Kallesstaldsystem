﻿using System;
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
    /// Interaction logic for Paddockoverview.xaml
    /// </summary>
    public partial class PaddockOverview : Page
    {
        PaddockMainViewModel pvm = new PaddockMainViewModel();
        public PaddockOverview()
        {
            InitializeComponent();
            DataContext = pvm;
        }

        private void UpdateSelectedPaddock(object sender, SelectionChangedEventArgs e)
        {
            pvm.GetHorsesOnSelectedPaddock();
        }
    }
}
