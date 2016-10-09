﻿using PrettySecureCloud.LoginService;

namespace PrettySecureCloud.CloudServices
{
	public class ServiceTypeViewModel
	{
		public ServiceTypeViewModel(ServiceType type)
		{
			Type = type;
			ImageName = $"{Type.Name.ToLower()}.png";
		}

		public ServiceType Type { get; }
		public string ImageName { get; }
	}
}