using GA.Collections;
using Xunit;

public class LinkedListTests
{
	[Fact]
	public void TestBasicAdd()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);
		list.Add(6);
		list.Add(-1);

		Assert.Equal(3, list.Count);
		Assert.Equal("1,6,-1", list.TestGetAsString());
	}

	#region Contains

	/// <summary>
	/// Tests the Contains method when the list is empty.
	/// </summary>
	[Fact]
	public void Contains_WhenEmpty_ReturnsFalse()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();

		bool result = list.Contains(1);

		Assert.False(result);
	}

	/// <summary>
	/// Tests the Contains method when the existing item is the only item in
	/// the list.
	/// </summary>
	[Fact]
	public void Contains_WhenSingleItemAndDesiredExists_RetursnTrue()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);

		bool result = list.Contains(1);

		Assert.True(result);
	}

	/// <summary>
	/// Tests the Contains method when there is only one item in the list and
	/// it is not the one searched for.
	/// </summary>
	[Fact]
	public void Contains_WhenSingleItemAndDesiredNotExists_ReturnsFalse()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);

		bool result = list.Contains(0);

		Assert.False(result);
	}

	/// <summary>
	/// Tests the Contains method when the desired item is the first one in the
	/// list.
	/// </summary>
	[Fact]
	public void Contains_WhenDesiredItemIsFirst_ReturnsTrue()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		bool result = list.Contains(1);

		Assert.True(result);
	}

	/// <summary>
	/// Tests the Contains method when the desired item is in the middle of the
	/// list.
	/// </summary>
	[Fact]
	public void Contains_WhenDesiredItemIsMiddle_ReturnsTrue()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		bool result = list.Contains(2);

		Assert.True(result);
	}

	/// <summary>
	/// Tests the contains method when the desired item is the last item in the
	/// list.
	/// </summary>
	[Fact]
	public void Contains_WhenDesiredItemIsLast_ReturnsTrue()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		bool result = list.Contains(3);

		Assert.True(result);
	}

	[Fact]
	public void Contains_WhenMultipleItemsAndDesiredNotExists_ReturnsFalse()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		bool result = list.Contains(0);

		Assert.False(result);
	}

	#endregion Contains


	#region Remove

	[Fact]
	public void Remove_WhenEmpty_ReturnsFalseAndLeavesUnchanged()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();

		bool result = list.Remove(99);

		Assert.False(result);
		Assert.Empty(list);
		Assert.Equal(0, list.Count);
		Assert.Equal("", list.TestGetAsString());
	}

	[Fact]
	public void Remove_WhenNotFound_ReturnsFalseAndLeavesUnchanged()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		bool result = list.Remove(99);

		Assert.False(result);
		Assert.Equal(3, list.Count);
		Assert.Equal("1,2,3", list.TestGetAsString());
	}

	[Fact]
	public void Remove_WhenOnlyItem_ReturnsTrueAndClearsList()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);

		bool result = list.Remove(1);

		Assert.True(result);
		Assert.Empty(list);
		Assert.Equal(0, list.Count);
		Assert.Equal("", list.TestGetAsString());
	}

	[Fact]
	public void Remove_WhenFirstItem_ReturnsTrueAndRemovesGiven()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		bool result = list.Remove(1);

		Assert.True(result);
		Assert.Equal(2, list.Count);
		Assert.Equal("2,3", list.TestGetAsString());
	}

	[Fact]
	public void Remove_WhenMiddleItem_ReturnsTrueAndRemovesGiven()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		bool result = list.Remove(2);

		Assert.True(result);
		Assert.Equal(2, list.Count);
		Assert.Equal("1,3", list.TestGetAsString());
	}

	[Fact]
	public void Remove_WhenLastItem_ReturnsTrueAndRemovesGiven()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);

		bool result = list.Remove(3);

		Assert.True(result);
		Assert.Equal(2, list.Count);
		Assert.Equal("1,2", list.TestGetAsString());
	}

	[Fact]
	public void Remove_WhenDuplicatesExist_ReturnsTrueAndRemovesFirstOccurence()
	{
		GA.Collections.LinkedList<int> list = new GA.Collections.LinkedList<int>();
		list.Add(1);
		list.Add(2);
		list.Add(3);
		list.Add(1);

		bool result = list.Remove(1);

		Assert.True(result);
		Assert.Equal(3, list.Count);
		Assert.Equal("2,3,1", list.TestGetAsString());
	}

	#endregion Remove
}
