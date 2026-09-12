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


	#region Removing Items

	[Fact]
	public void TestRemoveSingle()
	{
		GA.Collections.LinkedList<int> list = [1];
		Assert.True(list.Remove(1));
		Assert.Empty(list);
		Assert.Equal(0, list.Count);
		Assert.Equal("", list.TestGetAsString());
	}

	[Fact]
	public void TestRemoveFirst()
	{
		GA.Collections.LinkedList<int> list = [1, 0, 3, 0, 5];
		Assert.True(list.Remove(1));
		Assert.Equal(4, list.Count);
		Assert.Equal("0,3,0,5", list.TestGetAsString());
	}

	[Fact]
	public void TestRemoveFromMiddle()
	{
		GA.Collections.LinkedList<int> list = [1, 0, 3, 0, 5];
		Assert.True(list.Remove(3));
		Assert.Equal(4, list.Count);
		Assert.Equal("1,0,0,5", list.TestGetAsString());
	}

	[Fact]
	public void TestRemoveDuplicate()
	{
		GA.Collections.LinkedList<int> list = [1, 0, 3, 0, 5];
		Assert.True(list.Remove(0));
		Assert.Equal(4, list.Count);
		Assert.Equal("1,3,0,5", list.TestGetAsString());
		Assert.True(list.Remove(0));
		Assert.Equal(3, list.Count);
		Assert.Equal("1,3,5", list.TestGetAsString());
	}

	[Fact]
	public void TestRemoveLast()
	{
		GA.Collections.LinkedList<int> list = [1, 0, 3, 0, 5];
		Assert.True(list.Remove(5));
		Assert.Equal(4, list.Count);
		Assert.Equal("1,0,3,0", list.TestGetAsString());
	}

	#endregion Removing Items
}
