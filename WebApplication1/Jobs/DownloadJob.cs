using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication1.Jobs
{
	public class DownloadJob
	{
		public void DownloadFile(string fileUrl)
		{
			// Dosya indirmenin arka planda gerçekleşen kısmı
			var client = new WebClient();
			string destinationPath = @"C:\Temp\downloaded_image.jpg";
			client.DownloadFile(fileUrl, destinationPath);
		}
	}
}