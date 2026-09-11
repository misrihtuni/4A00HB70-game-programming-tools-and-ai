using System.Collections;
using System.Collections.Generic;

namespace GA.Collections
{
	public class LinkedList<T> : ICollection<T>
	{
		protected class Node
		{
			public T Value { get; set; }
			public Node Next { get; set; }
			public Node Previous { get; set; }

			public Node() : this(default(T))
			{
			}

			public Node(T value, Node next = null, Node previous = null)
			{
				Value = value;
				Next = next;
				Previous = previous;
			}
		}

		/// <summary>
		/// The head of the linked list. When the list is empty, this will be null.
		/// </summary>
		protected Node Head { get; set; } = null;

		/// <summary>
		/// The tail of the linked list. When the list is empty, this will be null.
		/// </summary>
		protected Node Tail { get; set; } = null;

		public int Count { get; private set; } = 0;

		public virtual bool IsReadOnly => false;

		public void Add(T item)
		{
			if (IsReadOnly)
			{
				throw new System.NotSupportedException("The collection is read-only.");
			}

			Node node = new Node(item);

			if (Head == null)
			{
				// When the list is empty.
				Head = node;
				Tail = Head;
			}
			else if (Tail == Head)
			{
				// When the list has only 1 item.
				Tail = node;
				Tail.Previous = Head;
				// Tail.Next automatically points to null here because of the Node's constructor.
			}
			else
			{
				// When the list has more than 1 item.
				// 1. Register new node as the next item in the list.
				// 2. Tell new node where the current tail is.
				// 3. Make new node the new tail of the list.

				Tail.Next = node;
				node.Previous = Tail;
				Tail = node;
			}

			Count++;
		}

		public void Clear()
		{
			if (IsReadOnly)
			{
				throw new System.NotSupportedException("The collection is read-only.");
			}

			Head = null;
			Tail = Head;
			Count = 0;
		}

		public bool Contains(T item)
		{
			Node current = Head;
			while (current != null)
			{
				if (EqualityComparer<T>.Default.Equals(current.Value, item))
				{
					return true;
				}

				current = current.Next;
			}

			return false;
		}

		public virtual void CopyTo(T[] array, int arrayIndex)
		{
			throw new System.NotImplementedException("Not nesessary for this example :D");
		}

		public IEnumerator<T> GetEnumerator()
		{
			Node current = Head;
			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}

		public bool Remove(T item)
		{
			if (IsReadOnly)
			{
				throw new System.NotSupportedException("This collection is read-only");
			}

			Node current = Head;
			Node previous = null;

			while (current != null)
			{
				if (EqualityComparer<T>.Default.Equals(current.Value, item))
				{
					if (previous != null)
					{
						// Removing any other element than the first.
						previous.Next = current.Next;
					}
					else
					{
						// Removing the first element.
						Head = current.Next;
					}

					Count--;
					return true;
				}

				previous = current;
				current = current.Next;
			}

			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}
}