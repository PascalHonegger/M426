﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using PrettySecureCloud.LoginService;
using Xamarin.Forms;

namespace PrettySecureCloud.Infrastructure
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public const string NavigationPushView = "Naviagion.PushView";

		protected static readonly LoginServiceClient Service = new LoginServiceClient(LoginServiceClient.EndpointConfiguration.BasicHttpsBinding_ILoginService);
		private int _workers;

		protected static void DisplayAlert<T>(T instance, MessageData message) where T : class
		{
			MessagingCenter.Send(instance, MessageData.DisplayAlert, message);
		}

		protected static void PushView<T>(T instance, Page page) where T : class
		{
			MessagingCenter.Send(instance, NavigationPushView, page);
		}

		public bool IsFree => !IsBusy;

		public bool IsBusy => Workers > 0;

		public int Workers
		{
			get { return _workers; }
			set
			{
				if(Equals(_workers, value)) return;
				_workers = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(IsBusy));
				OnPropertyChanged(nameof(IsFree));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
