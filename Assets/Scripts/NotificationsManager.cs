using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public static class NotificationsManager
{
	/// <summary>
	/// Creates a Notification Channel
	/// </summary>
	/// <param name="_ID"> Channel ID. </param>
	/// <param name="_name"> Channel Name. </param>
	/// <param name="_importance"> Importance of the Notification. </param>
	/// <param name="_description"> Description of the Channel. </param>
	public static void CreateNotificationChannel(string _ID = "channel_id", string _name = "Default Channel", Importance _importance = Importance.Default, string _description = "Generic notifications")
	{
		AndroidNotificationChannel channel = new AndroidNotificationChannel()
		{
			Id = _ID,
			Name = _name,
			Importance = _importance,
			Description = _description,
		};
		AndroidNotificationCenter.RegisterNotificationChannel(channel);
	}

	/// <summary>
	/// Sends a Notification with the given Channel ID, Title, Message and at the given Fire Time (when the notification will be send)
	/// The icons are optional! If left empty, the Default icon will be used instead.
	/// </summary>
	/// <param name="_ChannelID"> ID of the Notification Channel. </param>
	/// <param name="_Title"> Title of the Notifcation. </param>
	/// <param name="_Message"> Message of the Notifcation. </param>
	/// <param name="_FireTime"> When the Notification will be send. (a.k.a. Fired)</param>
	/// <param name="_SmallIcon"> Small icon that will be displayed next to the notification. </param>
	/// <param name="_LargeIcon"> Large icon that will be displayed next to the notification. </param>
	public static void SendNotification(string _ChannelID, string _Title, string _Message, System.DateTime _FireTime, string _SmallIcon, string _LargeIcon)
	{
		AndroidNotification notification = new AndroidNotification
		{
			Title = _Title,
			Text = _Message,
			FireTime = _FireTime,
			SmallIcon = _SmallIcon,
			LargeIcon = _LargeIcon
		};

		AndroidNotificationCenter.SendNotification(notification, _ChannelID);
	}
}
