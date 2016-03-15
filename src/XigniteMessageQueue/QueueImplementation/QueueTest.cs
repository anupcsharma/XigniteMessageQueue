using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XigniteMessageQueue.QueueImplementation
{
	public class QueueTest
	{
		public static void Main()
		{
			var queue = new QueueImplementation.Queue<int>();

			queue.Dequeue();

			//queue.Delete(node);
			queue.Enqueue(3);
			
			queue.Enqueue(6);
			queue.Enqueue(5);
			queue.Enqueue(8);
			queue.Dequeue();
			
			queue.Enqueue(7); 
			queue.Enqueue(1);
			queue.DeleteAllItems();

			queue.Enqueue(4);
			queue.Enqueue(2);
			queue.Enqueue(5);
			queue.Enqueue(9);

			//get node of nth element
			var nodeOfNthElement = queue.GetNode(9);
			queue.Delete(nodeOfNthElement);
			
			
			queue.GetAllItems();

			queue.Dequeue();
			queue.Dequeue();
		}
	}
}
