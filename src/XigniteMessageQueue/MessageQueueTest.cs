using System.Linq;
using NUnit.Framework;

namespace XigniteMessageQueue
{
	[TestFixture]
	public class MessageQueueTest
	{
		private MessageQueue _messageQueue;
		
		[SetUp]
		protected void Setup()
		{
			_messageQueue = new MessageQueue();
		}

		[Test]
		public void SendMessage_Test()
		{
			const string message = "Queue 1";
			_messageQueue.Send(message);

			Assert.AreEqual(message, _messageQueue.Dequeue().Body);
		}

		[Test]
		public void DeleteMessage_Test()
		{
			_messageQueue.Send("Queue 1");
			_messageQueue.Send("Queue 2");
			_messageQueue.Send("Queue 3");
			
			_messageQueue.Delete(new Message() {Body = "Queue 2"});

			var allmessages = _messageQueue.Receive();
			Assert.IsFalse(allmessages.Any(d => d.Body == "Queue 2"));

		}

		[Test]
		public void ReceiveMessages_Test()
		{
			_messageQueue.Send("Queue 1");
			_messageQueue.Send("Queue 2");
			_messageQueue.Send("Queue 3");

			var allmessages = _messageQueue.Receive();

			Assert.AreEqual(3, allmessages.Count());
		}

		[Test]
		public void ReceiveAndDelete_Test()
		{
			_messageQueue.Send("Queue 1");
			_messageQueue.Send("Queue 2");
			_messageQueue.Send("Queue 3");

			_messageQueue.ReceiveAndDelete();

			var allMessages = _messageQueue.Receive();

			Assert.IsNull(allMessages);
		}
	}
}
