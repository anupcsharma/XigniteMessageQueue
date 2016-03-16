using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XigniteMessageQueue
{
	public class MessageQueue : IMessageQueue
	{
		 private readonly QueueImplementation.Queue<Message> _queue = 
			new QueueImplementation.Queue<Message>();

		 /// <summary>
		 /// Sned a message to a message queue
		 /// </summary>
		 /// <param name="messageBody"></param>
		 /// <returns></returns>
		 public Message Send(string messageBody)
		 {
			 Message message = new Message { Body = messageBody };
			 lock (_queue)
			 {
				 _queue.Enqueue(message);
			 }
			 return message;
		 }

		/// <summary>
		/// Delete a message from a message queue
		/// </summary>
		/// <param name="item"></param>
		public void Delete(Message item)
		{
			//search node based on message
			var nodeToDelete = _queue.GetNode(item);
			lock (_queue)
			{
				_queue.Delete(nodeToDelete);
			}
		}

		/// <summary>
		/// Receives all messages from a message queue
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Message> Receive()
		{
			lock (_queue)
			{
				return _queue.GetAllItems();
			}
		}

		/// <summary>
		/// Receives all messages from a message queue and deletes all the messages
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Message> ReceiveAndDelete()
		{
			IEnumerable<Message> messages;
			lock (_queue)
			{
				messages = _queue.GetAllItems();
				_queue.DeleteAllItems();
			}
			return messages;
		}

		
		/*Methods below are just for testing*/
		/// <summary>
		/// Removes a first message from a message queue
		/// </summary>
		/// <returns></returns>
		public Message Dequeue()
		{
			Message message;
			lock (_queue)
			{
				message =_queue.Dequeue();
			}
			return message;
		}
	}
}
