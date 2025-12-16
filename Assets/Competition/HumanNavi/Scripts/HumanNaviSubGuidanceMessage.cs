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
	public enum GuidanceMessageDisplayType
	{
		All,
		RobotOnly,
		AvatarOnly,
		None,
	}

	//public interface IReceiveHumanNaviGuidanceMsgHandler : IEventSystemHandler
	//{
	//	void OnReceiveROSHumanNaviGuidanceMessage(RosBridge.human_navigation.HumanNaviGuidanceMsg guidaneMsg);
	//}

	public class HumanNaviSubGuidanceMessage : RosSubMessage<HumanNaviGuidanceMsg>
	{
		//public SAPIVoiceSynthesis tts;
		public SAPIVoiceSynthesisExternal tts;

		//--------------------------------------------------

		protected override void SubscribeMessageCallback(HumanNaviGuidanceMsg guidaneMsg)
		{
			SIGVerseLogger.Info("Received guide message: " + guidaneMsg.message + ", display type: " + guidaneMsg.display_type + ", source lang: " + guidaneMsg.source_language + ", target lang: " + guidaneMsg.target_language);

			this.tts.OnReceiveROSHumanNaviGuidanceMessage(guidaneMsg);
		}
	}
}
