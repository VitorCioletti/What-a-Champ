﻿namespace WhatAChamp
{
	using System.Windows;

	public partial class WhatAChampUI : Window
    {
        public WhatAChampUI()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) =>
            Close();

		public static void LoadSelectedChampion(Champion selectedChampion)
		{
			var existingWindow = Window.GetWindow(Application.Current.Windows[0]) as WhatAChampUI;

			existingWindow.GoBack.Visibility = Visibility.Visible;

			ChampionInfo.LoadSelectedChampion(selectedChampion, existingWindow);

			existingWindow.ChampList.Visibility = Visibility.Collapsed;
			existingWindow.ChampInfo.Visibility = Visibility.Visible;
		}

		private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			GoBack.Visibility = Visibility.Collapsed;

			ChampInfo.Visibility = Visibility.Collapsed;
			ChampList.Visibility = Visibility.Visible;
		}

		private void GoBack_Click(object sender, RoutedEventArgs e)
		{
			GoBack.Visibility = Visibility.Hidden;

			ChampInfo.Visibility = Visibility.Collapsed;
			ChampList.Visibility = Visibility.Visible;
		}
	}
}
