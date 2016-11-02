﻿namespace PrettySecureCloud.FileChooser
{
	public interface IPicture
	{
		/// <summary>
		/// Save a file to the phone
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="imageData"></param>
		/// <returns>True, if the file was saved successfully</returns>
		bool SavePictureToDisk(string filename, byte[] imageData);
	}
}
