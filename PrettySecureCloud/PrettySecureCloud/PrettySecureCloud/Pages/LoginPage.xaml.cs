﻿using System;
using PrettySecureCloud.Service_References.LoginService;
using Xamarin.Forms;

namespace PrettySecureCloud.Pages
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		void OnLoginClicked(object sender, EventArgs e)
		{
			var service = new LoginServiceClient(LoginServiceClient.EndpointConfiguration.BasicHttpBinding_ILoginService);
		    DisplayAlert("Fähler", "Da hetts di gnoh!", "Ja muesch ahneh");
		}

		void OnRegistrationClicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new NavigationPage(new RegistrationPage()));

		}

		void OnComplete(object sender, EventArgs e)
		{
			Entry entry = (Entry)sender;
			entry.PlaceholderColor = !string.IsNullOrEmpty(entry.Text) ? Color.Default : Color.Red;
			login.IsEnabled = !string.IsNullOrEmpty(usernameEntry.Text) && !string.IsNullOrEmpty(passwordEntry.Text);
		}

	}
}
