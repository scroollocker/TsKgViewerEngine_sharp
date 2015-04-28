using System;
using System.IO;
using System.Net;

namespace TSkgViewer
{
	public class HttpWrapper
	{
		public static String getRequestData(String url) 
		{	
			String result = "";
			WebRequest request = WebRequest.Create (url);

			request.Method = "GET";

			WebResponse response = request.GetResponse ();

			using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
				result = reader.ReadToEnd ();
			}

			return result;
		}

		private HttpWrapper () {

		}
	}
}

