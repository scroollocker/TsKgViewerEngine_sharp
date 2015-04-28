using System;

namespace TSkgViewer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var cat = TsCategory.Instance;

			var catLis = cat.Categories;

			foreach (var item in catLis) {
				Console.Write ("Val "+item.CategoryIndex);
				Console.WriteLine (" text "+item.CategoryName);
			}


		}
	}
}
