using LanguageExt;
using LanguageExt.SomeHelp;
using PassingTheCodingTestQuestions;

namespace TestProject1;

[TestFixture]
public class ExtensionTests
{
    [Test]
    public void TestInjectMiddle()
    {
        int[] arr = { 1, 2, 4, 5 };
        int[] expected = { 1, 2, 3, 4, 5 };
        int[] result = arr.Inject(3, 2);
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void TestInjectStart()
    {
        int[] arr = { 1, 2, 3 };
        int[] expected = { 0, 1, 2, 3 };
        int[] result = arr.Inject(0, 0);
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void TestInjectEnd()
    {
        int[] arr = { 1, 2, 3 };
        int[] expected = { 1, 2, 3, 4 };
        int[] result = arr.Inject(4, 3);
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void TestInvalidIndexNegative()
    {
        int[] arr = { 1, 2, 3 };
        Assert.Throws<IndexOutOfRangeException>(() => arr.Inject(4, -1));
    }

    [Test] 
    public void TestInvalidIndexGreaterThanLength()
    {
        int[] arr = { 1, 2, 3 };
        Assert.Throws<IndexOutOfRangeException>(() => arr.Inject(4, 5));
    }

    [Test]
    public void TestEmptyArray()
    {
        int[] arr = { };
        int[] expected = { 1 };
        int[] result = arr.Inject(1, 0);
        CollectionAssert.AreEqual(expected, result);
    }
    
    [Test]
    public void TestGetImmediateRightMemberMiddle()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        Option<int> result = 2.GetImmediateRightMember(arr);
        Assert.IsTrue(result.IsSome);
        result.Match(None: () => Assert.Fail(), Some: i => Assert.That(i, Is.EqualTo(3)));
    }
    
    [Test]
    public void TestGetImmediateRightMemberFirst()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        Option<int> result = 1.GetImmediateRightMember(arr);
        Assert.IsTrue(result.IsSome);
        result.Match(None: () => Assert.Fail(), Some: i => Assert.That(i, Is.EqualTo(2)));
    }
    
    [Test]
    public void TestGetImmediateRightMemberBeforeLast()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        Option<int> result = 4.GetImmediateRightMember(arr);
        Assert.IsTrue(result.IsSome);
        result.Match(None: () => Assert.Fail(), Some: i => Assert.That(i, Is.EqualTo(5)));
    }

    [Test]
    public void TestGetImmediateRightMemberLast()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        Option<int> result = 5.GetImmediateRightMember(arr);
        Assert.IsFalse(result.IsSome);
    }

    [Test]
    public void TestValueNotInArray()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        Option<int> result = 6.GetImmediateRightMember(arr);
        Assert.IsFalse(result.IsSome);
    }

    [Test]
    public void GetImmediateRightMember_TestEmptyArray()
    {
        int[] arr = { };
        Option<int> result = 1.GetImmediateRightMember(arr);
        Assert.IsFalse(result.IsSome);
    }
}
