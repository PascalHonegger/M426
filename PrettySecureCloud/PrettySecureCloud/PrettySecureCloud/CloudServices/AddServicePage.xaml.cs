﻿using PrettySecureCloud.Infrastructure;

namespace PrettySecureCloud.CloudServices
{
	public partial class AddServicePage
	{
		public AddServicePage(AddServiceViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = viewModel;
		}

		protected override void OnAppearing()
		{
			this.Subscribe<AddServiceViewModel, AddServicePage>();
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			this.Unsubscribe<AddServiceViewModel, AddServicePage>();
			base.OnDisappearing();
		}
	}
}
