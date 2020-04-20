using ShabdkoshApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShabdkoshApp.ViewModels
{
	public class WordDetailsViewModel : BaseViewModel
	{
		public WordItem WordItem;
		public WordDetailsViewModel(WordItem item)
		{
			Title = "Word Details";
			WordItem = new WordItem()
			{
				Word = item.Word,
				Meaning = item.Meaning
			};
		}
	}
}
