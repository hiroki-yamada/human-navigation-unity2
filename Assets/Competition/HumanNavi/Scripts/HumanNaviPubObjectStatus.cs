using UnityEngine;
using UnityEngine.EventSystems;
using SIGVerse.RosBridge;
using SIGVerse.RosBridge.sensor_msgs;
using SIGVerse.Common;
using System.Collections.Generic;
using System;
using SIGVerse.RosBridge.human_navigation_msgs.msg;

namespace SIGVerse.Competition.HumanNavigation
{
	public interface IRosObjectStatusSendHandler : IEventSystemHandler
	{
		void OnSendRosObjectStatusMessage(HumanNaviObjectStatus message);
	}

	public class HumanNaviPubObjectStatus : RosPubMessage<HumanNaviObjectStatus>, IRosObjectStatusSendHandler
	{
		public void OnSendRosObjectStatusMessage(HumanNaviObjectStatus message)
		{
//			SIGVerseLogger.Info("Send Object Status message:");
			SIGVerseLogger.Info("Target object : " + message.target_object.name + " " + message.target_object.position);

			//foreach (RosBridge.human_navigation.HumanNaviObjectInfo objInfo in message.non_target_objects)
			//{
			//	SIGVerseLogger.Info("Non-target object : " + objInfo.name + " " + objInfo.position + " " + objInfo.orientation);
			//}

			HumanNaviObjectStatus rosMessage = new HumanNaviObjectStatus
			(
				message.target_object,
				message.non_target_objects
			);

			this.publisher.Publish(rosMessage);
		}
	}
}

