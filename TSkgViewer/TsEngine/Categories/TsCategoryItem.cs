using System;

namespace TSkgViewer
{
	public struct TsCategoryItem
	{
		private String categoryIndex;
		private String categoryName;

		public TsCategoryItem(String index, String name) {
			categoryIndex = index;
			categoryName = name;
		}

		public String CategoryIndex {
			get {
				return categoryIndex;
			}
			set {
				categoryIndex = value;
			}
		}

		public string CategoryName {
			get {
				return this.categoryName;
			}
			set {
				categoryName = value;
			}
		}


	}
}

