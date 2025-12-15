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
	public interface IReceiveHumanNaviMsgHandler : IEventSystemHandler
	{
		void OnReceiveRosMessage(HumanNaviMsg humanNaviMsg);
	}

	public class HumanNaviSubMessage : RosSubMessage<HumanNaviMsg>
	{
		public List<GameObject> destinations;

		protected override void SubscribeMessageCallback(HumanNaviMsg humanNaviMsg)
		{
			SIGVerseLogger.Info("Received message :" + humanNaviMsg.message);

			foreach (GameObject destination in this.destinations)
			{
				ExecuteEvents.Execute<IReceiveHumanNaviMsgHandler>
				(
					target: destination,
					eventData: null,
					functor: (reciever, eventData) => reciever.OnReceiveRosMessage(humanNaviMsg)
				);
			}
		}
	}
}
