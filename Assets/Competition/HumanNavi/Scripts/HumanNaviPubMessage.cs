using UnityEngine;
using UnityEngine.EventSystems;
using SIGVerse.RosBridge;
using SIGVerse.Common;
using SIGVerse.RosBridge.human_navigation_msgs.msg;

namespace SIGVerse.Competition.HumanNavigation
{
	public interface IRosHumanNaviMessageSendHandler : IEventSystemHandler
	{
		void OnSendRosHumanNaviMessage(string message, string detail);
	}

	public class HumanNaviPubMessage : RosPubMessage<HumanNaviMsg>, IRosHumanNaviMessageSendHandler
	{
		public void OnSendRosHumanNaviMessage(string message, string detail)
		{
			SIGVerseLogger.Info("Sending message : " + message + ", " + detail);

			HumanNaviMsg humanNaviMsg = new HumanNaviMsg();
			humanNaviMsg.message = message;
			humanNaviMsg.detail = detail;

			this.publisher.Publish(humanNaviMsg);
		}
	}
}

