﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using PrettySecureCloud.LoginService;

namespace PrettySecureCloud.CloudServices.Implementations
{
	public interface ICloudService
	{
		string CustomName { get; set; }

		ServiceTypeViewModel CloudServiceType { get; }

		CloudService Model { get; set; }

		IEnumerable<IFile> FileStructure { get; }

		Task<string> AuthenticateLoginTokenAsync();

		void UploadFile(StreamReader source, IFile target);

		StreamReader DownloadFile(IFile target);
	}
}
