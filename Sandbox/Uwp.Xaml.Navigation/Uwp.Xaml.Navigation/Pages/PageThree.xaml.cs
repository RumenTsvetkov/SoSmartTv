﻿using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Uwp.Xaml.Navigation.Navigation;
using Uwp.Xaml.Navigation.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Uwp.Xaml.Navigation.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class PageThree : Page
	{
		public PageThree()
		{
			this.InitializeComponent();
			Debug.WriteLine(string.Format("Creating: {0}", GetType().Name));

			//ViewModel = new PageThreeViewModel(NavigationServiceProvider.GetNavigationService());
		}

		//public PageThreeViewModel ViewModel { get; }
	}
}
