﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShabdkoshApp.Models
{
	public enum MenuItemType
	{
		Browse,
		Settings,
		About
	}
	public class HomeMenuItem
	{
		public MenuItemType Id { get; set; }

		public string Title { get; set; }
	}
}
