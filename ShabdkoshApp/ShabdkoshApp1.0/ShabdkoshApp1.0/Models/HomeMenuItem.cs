﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShabdkoshApp1._0.Models
{
	public enum MenuItemType
	{
		Browse,
		About,
		Settings
	}
	public class HomeMenuItem
	{
		public MenuItemType Id { get; set; }

		public string Title { get; set; }
	}
}
