using System;

namespace TSkgViewer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			/* fast category test
			var cat = TsCategory.Instance;

			var catLis = cat.Categories;

			foreach (var item in catLis) {
				Console.Write ("Val "+item.CategoryIndex);
				Console.WriteLine (" text "+item.CategoryName);
			}
			*/

			/* fast serial list test */
			TsSerialsList slist = TsSerialsList.Instance;

			var list = slist.getSerialsList ("5");

			foreach (var item in list) {
				Console.WriteLine (item.SerialCaption);
			}

		}
	}
}
