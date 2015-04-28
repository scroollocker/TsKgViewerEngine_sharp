using System;
using System.Collections.Generic;
using CsQuery;

namespace TSkgViewer
{
	public class TsSerialsList
	{
		private List<TsSerialListItem> serialsList;
		private String cacheCategoryIndex;

		private static TsSerialsList instance = null;

		public static TsSerialsList Instance {
			get {
				if (instance == null) {
					instance = new TsSerialsList ();
				}
				return instance;
			}
		}

		public List<TsSerialListItem> SerialsList {
			get {
				if (serialsList.Count == 0) {
					if (cacheCategoryIndex.Length > 0) {
						serialsList = parseSerialsInCategory (cacheCategoryIndex);
					}
				}
				return this.serialsList;
			}
		}

		public List<TsSerialListItem> getSerialsList(String cat,bool cache = false) {
			List<TsSerialListItem> result = new List<TsSerialListItem>();
			if (cache) {
				result = this.SerialsList;
			} else {
				result = parseSerialsInCategory (cat);
			}
			return result;
		}

		private List<TsSerialListItem> parseSerialsInCategory(String cat) {
			List<TsSerialListItem> result = new List<TsSerialListItem>();

			cacheCategoryIndex = cat;

			String categoryUrl = TsCategoryHelper.makeCategoryUrl (cat);
			String categoryContent = HttpWrapper.getRequestData (categoryUrl);

			do {
				if (categoryContent != null && categoryContent.Length > 0) {
					var document = CQ.Create(categoryContent);
					var serials = document.Select("div.show a");

					if (serials.Length == 0) {
						break;
					}

					foreach(var serial in serials) {
						String url = TsUtils.BaseUrl+serial.GetAttribute("href");
						String imgUrl = TsUtils.BaseUrl+serial.FirstElementChild.GetAttribute("src");
						String capt = serial.LastElementChild.InnerText;

						result.Add(new TsSerialListItem(capt,imgUrl,url));
					}

					var nextItem = document.Select("li.next a").FirstElement();

					if (nextItem == null) {
						break;
					}

					String nextUrl = TsUtils.BaseUrl+nextItem.GetAttribute("href");

					categoryContent = HttpWrapper.getRequestData (nextUrl);
				}
				else {
					break;
				}

			} while(true);

			return result;
		}

		private TsSerialsList ()
		{
			serialsList = new List<TsSerialListItem> ();
			cacheCategoryIndex = "";
		}
	}
}

