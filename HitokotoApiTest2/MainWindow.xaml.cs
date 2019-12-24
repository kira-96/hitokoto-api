﻿using System.Windows;

namespace HitokotoApiTest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private async void OnRefreshClick(object sender, RoutedEventArgs e)
        {
            if ((DataContext as MainViewModel).IsBusy)
                return;

            await (DataContext as MainViewModel).RefreshHitokoto();
        }
    }
}
