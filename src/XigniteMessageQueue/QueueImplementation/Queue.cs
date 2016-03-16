using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XigniteMessageQueue.QueueImplementation
{
	/// <summary>
	/// Linkedlist node
	/// </summary>
	public class Node<T>
	{
		public Node<T> Next;
		public T Data;

		public Node(T data)
		{
			this.Data = data;
		}
	}

	/// <summary>
	/// Implementation of queue using Linkedlist
	/// </summary>
	public class Queue<T> 
	{
		private Node<T> _firstNode;
		private Node<T> _lastNode;

		/// <summary>
		/// Add item at the end of the queue
		/// </summary>
		/// <param name="enqueueData"></param>
		public void Enqueue(T enqueueData)
		{
			Node<T> newLastNode = new Node<T>(enqueueData);
			if (_firstNode == null)
			{
				_lastNode = newLastNode;
				_firstNode = _lastNode;
			}
			else
			{
				_lastNode.Next = newLastNode;
				_lastNode = _lastNode.Next;
			}
		}

		/// <summary>
		/// Removes first item from the queue
		/// </summary>
		/// <returns></returns>
		public T Dequeue()
		{
			if (_firstNode != null)
			{
				T dequeueData = _firstNode.Data;
				_firstNode = _firstNode.Next;
				return dequeueData;
			}

			return default(T);
		}

		/// <summary>
		/// Deletes a current item
		/// </summary>
		/// <param name="node"></param>
		public void Delete(Node<T> node)
		{
			if (node == null)
				return;

			if (node.Next == null)
			{
				RemoveLastNode();
			}
			else
			{
				node.Data = node.Next.Data;
				node.Next = node.Next.Next;
			}
		}

		/// <summary>
		/// Delete all items from the queue;
		/// Nullifies the queue
		/// </summary>
		public void DeleteAllItems()
		{
			_firstNode = null;
			_lastNode = null;

		}

		/// <summary>
		/// Return all items from the queue
		/// </summary>
		/// <returns></returns>
		public IEnumerable<T> GetAllItems()
		{
			if (_firstNode == null)
				return null;
			Node<T> tempNode = _firstNode;
			var items = new List<T>();
			while (tempNode.Next != null)
			{
				items.Add(tempNode.Data);
				tempNode = tempNode.Next;
			}

			items.Add(tempNode.Data);
			return items;
		}

		/// <summary>
		/// Get a node given a data parameter
		/// </summary>
		/// <param name="data"></param>
		/// <returns>Node</returns>
		public Node<T> GetNode(T data)
		{
			Node<T> node = _firstNode;
			Node<T> outNode;
			while (node.Next != null)
			{
				if (GetNode(data, node, out outNode)) 
					return outNode;
				node = node.Next;
			}
			GetNode(data, node, out outNode);
			return outNode;
		}
		
		/// <summary>
		/// Delete a last node
		/// </summary>
		public void RemoveLastNode()
		{
			Node<T> node = _firstNode;
			Node<T> previousNode = null;
			while (node.Next != null) 
			{
				previousNode = node;
				node = node.Next;
			}
			
			if (previousNode == null)
			{
				_firstNode = null;
			}
			else
			{
				previousNode.Next = null;
			}
		}

		#region private methods

		private static bool GetNode(T data, Node<T> node, out Node<T> outNode)
		{
			if (typeof(T) == typeof(int) || typeof(T) == typeof(string))
			{
				if (node.Data.Equals(data))
				{
					outNode = node;
					return true;
				}
			}
			else
			{
				if (Utils.Compare(node.Data, data, ""))
				{
					outNode = node;
					return true;
				}
			}
			outNode = null;
			return false;
		}

		#endregion
	}
}
