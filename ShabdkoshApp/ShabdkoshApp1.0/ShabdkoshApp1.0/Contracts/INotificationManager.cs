﻿namespace ShabdkoshApp1._0.Contracts
{
	using System;

	public interface INotificationManager
	{
		event EventHandler NotificationReceived;

		void Initialize();

		int ScheduleNotification(string title, string message);

		void ReceiveNotification(string title, string message);
	}
}
