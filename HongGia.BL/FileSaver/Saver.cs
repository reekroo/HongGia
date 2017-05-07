using System;
using System.Diagnostics;
using System.Web;
using HongGia.Core.Interfaces.Base;

using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v2.Data;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace HongGia.BL.FileSaver
{
	public class Saver
	{
		private HttpPostedFileBase _fileBase;
		private IImage _fileData;

		public Saver(HttpPostedFileBase fileBase, IImage fileData)
		{
			_fileBase = fileBase;
			_fileData = fileData;
		}

		public void Save()
		{
			GoogleConnection();
		}

		private void GoogleConnection()
		{
			string[] scopes = new string[]
			{
				DriveService.Scope.Drive,
				DriveService.Scope.DriveFile
			};

			var clientId = "431429228503-jo93hs7l5gb05sqnt837j95c9p5cuj4l.apps.googleusercontent.com";      // From https://console.developers.google.com 
			var clientSecret = "qJNFCXCAH259m29sQDwbvPg1";                                                  // From https://console.developers.google.com

			// here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%

			var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
				new ClientSecrets
				{
					ClientId = clientId,
					ClientSecret = clientSecret
				},
				scopes,
				Environment.UserName,
				CancellationToken.None,
				new FileDataStore("HongGia")
			).Result;

			var service = new DriveService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = "HongGia",
			});
		}

		//private void GoogleConnection()
		//{
		//	string[] scopes = new string[] { DriveService.Scope.Drive }; // Full access

		//	var keyFilePath = @"C:\Users\reekroo\Downloads\gioia-business-template\assets\img\slider\1.jpg";

		//	var serviceAccountEmail = "paul.davidovski@gmail.com"; // found https://console.developers.google.com

		//	var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);

		//	var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail) { Scopes = scopes }.FromCertificate(certificate));
		//}
	}
}
