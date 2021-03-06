﻿using System;
using PrettySecureCloud.Infrastructure;
using Xamarin.Forms;

namespace PrettySecureCloud.CloudServices.ServiceChooser
{
	/// <summary>
	/// Class to choose a Service
	/// </summary>
	public partial class ServiceChooserPage
	{
		private readonly ServiceChooserViewModel _viewModel;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceChooserPage" /> class.
		/// </summary>
		public ServiceChooserPage()
		{
			InitializeComponent();


			_viewModel = new ServiceChooserViewModel();
			BindingContext = _viewModel;
			ListViewService.Footer = string.Empty;
		}

		/// <inheritdoc />
		protected override void OnAppearing()
		{
			this.Subscribe<ServiceChooserViewModel, ServiceChooserPage>();
			base.OnAppearing();
		}

		/// <inheritdoc />
		protected override void OnDisappearing()
		{
			this.Unsubscribe<ServiceChooserViewModel, ServiceChooserPage>();
			base.OnDisappearing();
		}

		private async void MenuItem_OnClickedDelete(object sender, EventArgs e)
		{
			var menuItem = (MenuItem)sender;
			var clickedService = (ICloudService)menuItem.CommandParameter;

			var confirm = await DisplayAlert("Wirklich löschen?", $"\"{clickedService.CustomName}\" wirklich löschen?", "Ja", "Nein");

			if (confirm)
			{
				_viewModel.DeleteService(clickedService);
			}
		}

		private void MenuItem_OnClickedEdit(object sender, EventArgs e)
		{
			var menuItem = (MenuItem)sender;
			var clickedService = (ICloudService)menuItem.CommandParameter;

			_viewModel.EditService(clickedService);
		}
	}
}