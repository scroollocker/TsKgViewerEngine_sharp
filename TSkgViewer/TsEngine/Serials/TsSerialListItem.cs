using System;

namespace TSkgViewer
{
	public struct TsSerialListItem
	{
		private String serialCaption;
		private String serialImgUrl;
		private String serialUrl;

		public TsSerialListItem(String cap,String img, String url) {
			serialCaption = cap;
			serialImgUrl = img;
			serialUrl = url;
		}

		public string SerialCaption {
			get {
				return this.serialCaption;
			}
			set {
				serialCaption = value;
			}
		}

		public string SerialImgUrl {
			get {
				return this.serialImgUrl;
			}
			set {
				serialImgUrl = value;
			}
		}

		public string SerialUrl {
			get {
				return this.serialUrl;
			}
			set {
				serialUrl = value;
			}
		}

	}
}

