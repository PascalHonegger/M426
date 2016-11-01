﻿using System.IO;
using System.Threading.Tasks;
using PrettySecureCloud.CloudServices;
using PrettySecureCloud.Infrastructure;
using Xamarin.Forms;

namespace PrettySecureCloud.FileChooser
{
	public class FileDetailsViewModel : ViewModelBase
	{
		private IFile _selectedFile;
		private readonly ICloudService _cloudService;

		public IFile SelectedFile
		{
			get
			{
				return _selectedFile;
			}
			set
			{
				if (Equals(_selectedFile, value)) return;
				_selectedFile = value;
				OnPropertyChanged();
				DownloadCommand.ChangeCanExecute();
			}
		}

		public Command DownloadCommand { get; }

		public FileDetailsViewModel(IFile selectedFile, ICloudService cloudService)
		{
			DownloadCommand = new Command(async () => await DownloadFileAsync(), CanDownloadFile);

			SelectedFile = selectedFile;
			_cloudService = cloudService;
		}

		private bool CanDownloadFile() => SelectedFile != null;

		public async Task DownloadFileAsync()
		{
			Workers++;
			var file = await _cloudService.DownloadFile(SelectedFile);

			using (var ms = new MemoryStream())
			{
				await file.CopyToAsync(ms);

				var data = ms.ToArray();

				if (Equals(SelectedFile.FileType, FileChooserViewModel.FileExtension))
				{
					data = CurrentSession.Encryptor.Decrypt(data, CurrentSession.CurrentUser.EncryptionKey);
				}

				DependencyService.Get<IPicture>().SavePictureToDisk(Path.GetFileNameWithoutExtension(SelectedFile.FileName), data);
			}

			Workers--;
		}
	}
}
