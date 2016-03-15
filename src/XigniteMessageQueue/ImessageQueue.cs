using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XigniteMessageQueue
{
	public interface IMessageQueue
	{
		void Delete(Message item);
		IEnumerable<Message> Receive();
		IEnumerable<Message> ReceiveAndDelete();
		Message Send(string messageBody);
	}
}
