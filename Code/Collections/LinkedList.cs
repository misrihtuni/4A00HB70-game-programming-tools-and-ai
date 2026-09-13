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
			else
			{
				// When the list is not empty.
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

			while (current != null)
			{
				// There are still items in the list that haven't been checked.
				if (EqualityComparer<T>.Default.Equals(current.Value, item))
				{
					// The current node contains the item to remove.
					// Cache refs to both the next node and the previous node.
					Node next = current.Next;
					Node previous = current.Previous;

					if (Head == Tail)
					{
						// Removing the only item in the list.
						Head = null;
						Tail = null;
					}
					else if (current.Previous == null)
					{
						// Removing the first element in the list.
						next.Previous = null;
						Head = next;
					}
					else if (current.Next == null)
					{
						// Removing the last element in the list.
						previous.Next = null;
						Tail = previous;
					}
					else
					{
						// Removing any other element in the list.
						previous.Next = next;
						next.Previous = previous;
					}

					Count--;
					return true;
				}

				// Move on to the next node.
				current = current.Next;
			}

			// Given item was not found.
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#region For Testing Only!
		/// <summary>
		/// This method is for testing purposes only.<br/>
		/// Returns the value stored at the given index.
		/// </summary>
		///
		/// <remarks>
		/// This method will always start from <see cref="Head"/> and traverse
		/// the list until the counter hits the given <paramref name="index"/>.
		/// Complexity is O(n).
		/// </remarks>
		public T TestGetValue(int index)
		{
			if (Count == 0)
			{
				throw new System.InvalidOperationException("The list is empty.");
			}
			else if (index >= Count || index < 0)
			{
				throw new System.ArgumentOutOfRangeException(nameof(index));
			}

			Node currentNode = Head;
			int currentIndex = 0;

			while (currentIndex != index)
			{
				currentNode = currentNode.Next;
				currentIndex++;
			}

			return currentNode.Value;
		}

		/// <summary>
		/// This method is for testing purposes only.<br/>
		/// Returns the list as a string where the values are separated with
		/// commas.
		/// </summary>
		///
		/// <remarks>
		/// This method will always traverse the whole list.
		/// Complexity is O(n).
		/// </remarks>
		public string TestGetAsString()
		{
			string text = "";
			Node current = Head;

			while (current != null)
			{
				text += $"{current.Value}";
				if (current.Next != null)
				{
					text += ",";
				}
				current = current.Next;
			}

			return text;
		}
		#endregion For Testing Only!
	}
}
