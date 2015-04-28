using System;
using CsQuery;
using System.Collections.Generic;

namespace TSkgViewer
{
	public class TsCategory
	{
		private List<TsCategoryItem> categoryItems = null;

		private static TsCategory instance = null;

		public static TsCategory Instance {
			get {
				if (instance == null) {
					instance = new TsCategory();
				}
				return instance;
			}
		}

		public List<TsCategoryItem> Categories {
			get {
				if (categoryItems.Count == 0) {
					categoryItems = parseCategoryList ();
				}

				return this.categoryItems;
			}
		}

		public List<TsCategoryItem> getCategories(bool cache = false) {
			List<TsCategoryItem> result;
			if (cache) {
				result = this.Categories;
			} else {
				result = parseCategoryList ();
			}

			return result;
		}

		private List<TsCategoryItem> parseCategoryList() {
			List<TsCategoryItem> result = new List<TsCategoryItem> ();

			String categoryUrlPath = TsUtils.BaseUrl + "/show";

			String categoryContent = HttpWrapper.getRequestData (categoryUrlPath);

			if (categoryContent != null && categoryContent.Length > 0) {
				var doc = CQ.Create (categoryContent);

				if (doc != null) {
					var categories = doc.Select ("select#filter-category option");
					String catVal;
					String catName;
					foreach(var category in categories) {
						catVal = category.GetAttribute("value");
						catName = category.InnerText;

						/* leave All Categories item */
						if (catVal == "0") {
							continue;
						}

						result.Add (new TsCategoryItem (catVal, catName));
					}

				}
			}
			return result;
		}

		private TsCategory ()
		{
			categoryItems = new List<TsCategoryItem> ();
		}


	}
}

