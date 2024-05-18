﻿using ApplicationLayer.Viewmodels;
using Stable_management_system.Pages;
using System.Windows;

namespace StableManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HorseOverviewButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Horseoverview();
        }

        private void PaddockOverviewButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new PaddockOverview();
        }
    }
}