using System;

namespace TSkgViewer
{
	public class TsCategoryHelper
	{
		
		public static String makeCategoryUrl(String index,TsSortEnum sort = TsSortEnum.SORT_A, String genre = "0") {

			String sortVal = "";


			switch(sort) {
				case TsSortEnum.SORT_A: {
				sortVal = "a";
				break;
			}

				case TsSortEnum.SORT_Z: {
				sortVal = "z";
				break;
			}

				case TsSortEnum.SORT_NEW: {
				sortVal = "new";
				break;
			}
			}

			String[] formatStr = new string[4];
			formatStr [0] = TsUtils.BaseUrl;
			formatStr [1] = index;
			formatStr [2] = sortVal;
			formatStr [3] = genre;


			String result = String.Format ("{0}/show?category={1}&genre={3}&star=0&sort={2}&zero=0&year=0", formatStr);

			return result;
		}

		private TsCategoryHelper ()
		{
		}
	}
}

