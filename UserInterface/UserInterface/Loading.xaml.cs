﻿namespace UserInterface
{
	using System.Windows;

	public partial class Loading : Window
	{
		public Loading()
		{
			InitializeComponent();

			Show();

			new WhatAChamp().Show();

			Close();
		}
	}
}