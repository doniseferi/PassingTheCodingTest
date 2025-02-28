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
        var result = arr.Inject(3, 2);
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void TestInjectStart()
    {
        int[] arr = { 1, 2, 3 };
        int[] expected = { 0, 1, 2, 3 };
        var result = arr.Inject(0, 0);
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void TestInjectEnd()
    {
        int[] arr = { 1, 2, 3 };
        int[] expected = { 1, 2, 3, 4 };
        var result = arr.Inject(4, 3);
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
        var result = arr.Inject(1, 0);
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void TestGetImmediateRightMemberMiddle()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        var result = 2.GetImmediateRightMember(arr);
        Assert.IsTrue(result.IsSome);
        result.Match(None: () => Assert.Fail(), Some: i => Assert.That(i, Is.EqualTo(3)));
    }

    [Test]
    public void TestGetImmediateRightMemberFirst()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        var result = 1.GetImmediateRightMember(arr);
        Assert.IsTrue(result.IsSome);
        result.Match(None: () => Assert.Fail(), Some: i => Assert.That(i, Is.EqualTo(2)));
    }

    [Test]
    public void TestGetImmediateRightMemberBeforeLast()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        var result = 4.GetImmediateRightMember(arr);
        Assert.IsTrue(result.IsSome);
        result.Match(None: () => Assert.Fail(), Some: i => Assert.That(i, Is.EqualTo(5)));
    }

    [Test]
    public void TestGetImmediateRightMemberLast()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        var result = 5.GetImmediateRightMember(arr);
        Assert.IsFalse(result.IsSome);
    }

    [Test]
    public void TestValueNotInArray()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        var result = 6.GetImmediateRightMember(arr);
        Assert.IsFalse(result.IsSome);
    }

    [Test]
    public void GetImmediateRightMember_TestEmptyArray()
    {
        int[] arr = { };
        var result = 1.GetImmediateRightMember(arr);
        Assert.IsFalse(result.IsSome);
    }

    [Test]
    public void InjectToLeftOf_WithMultipleValuesPresent_InsertsAtFirstOccurrence()
    {
        var originalArray = new[] { 4, 5, 7, 5 };
        var expectedArray = new[] { 4, 8, 5, 7, 5 };

        var updatedArray = originalArray.InjectToLeftOf(5, 8);

        Assert.IsTrue(updatedArray.SequenceEqual(expectedArray));
    }

    [Test]
    public void InjectToLeftOf_WithValueNotPresent_ThrowsException()
    {
        var originalArray = new[] { 4, 7, 9 };

        Assert.Throws<ArgumentException>(() => originalArray.InjectToLeftOf(5, 8));
    }

    [Test]
    public void InjectToLeftOf_OnEmptyArray_ThrowsException()
    {
        var emptyArray = new int[] { };

        Assert.Throws<ArgumentException>(() => emptyArray.InjectToLeftOf(5, 8));
    }

    [Test]
    public void InjectToLeftOf_WithTargetValueAtFirstIndex_ReturnsAnEmptyArray()
    {
        var originalArray = new[] { 5, 4, 7 };
        var expectedArray = new int[] { };

        var updatedArray = originalArray.InjectToLeftOf(5, 8);

        Assert.IsTrue(updatedArray.SequenceEqual(expectedArray));
    }

    [Test]
    public void InjectToLeftOf_WithTargetValueNotAtFirstIndex_InsertsCorrectly()
    {
        var originalArray = new[] { 4, 5, 7 };
        var expectedArray = new[] { 4, 8, 5, 7 };

        var updatedArray = originalArray.InjectToLeftOf(5, 8);

        Assert.IsTrue(updatedArray.SequenceEqual(expectedArray));
    }

    [Test]
    public void InjectToLeftOf_WithTargetValueAtLastIndex_InsertsCorrectly()
    {
        var originalArray = new[] { 4, 7, 5 };
        var expectedArray = new[] { 4, 7, 8, 5 };

        var updatedArray = originalArray.InjectToLeftOf(5, 8);

        Assert.IsTrue(updatedArray.SequenceEqual(expectedArray));
    }

    [TestFixture]
    public class IntArrayExtensionsTests
    {
        [Test]
        public void LeftElementsOf_SubjectInMiddle_ReturnsCorrectElements()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] expected = { 1, 2, 3 };
            var result = array.LeftElementsOf(4);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void LeftElementsOf_SubjectAtStart_ReturnsEmptyArray()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] expected = { };
            var result = array.LeftElementsOf(1);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void LeftElementsOf_SubjectNotInArray_ReturnsEmptyArray()
        {
            int[] array = { 1, 2, 3, 4, 5 };

            Assert.Throws<ArgumentException>(() => array.LeftElementsOf(6));
        }

        [Test]
        public void LeftElementsOf_EmptyArray_ReturnsEmptyArray()
        {
            int[] array = { };
            int[] expected = { };
            var result = array.LeftElementsOf(1);

            Assert.AreEqual(expected, result);
        }
    }

    [Test]
    public void Except_ValueExists_ReturnsArrayWithoutValue()
    {
        int[] array = { 1, 2, 3, 4 };
        int[] expected = { 1, 3, 4 };
        var result = array.Except(2);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Except_ValueDoesNotExist_ReturnsSameArray()
    {
        int[] array = { 1, 2, 3, 4 };
        int[] expected = { 1, 2, 3, 4 };
        var result = array.Except(5);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Except_ArrayHasMultipleInstances_ReturnsArrayWithoutAnyInstances()
    {
        int[] array = { 1, 2, 2, 3, 4, 2 };
        int[] expected = { 1, 3, 4 };
        var result = array.Except(2);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Except_EmptyArray_ReturnsEmptyArray()
    {
        int[] array = { };
        int[] expected = { };
        var result = array.Except(1);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Except_ValueIsLastElement_ReturnsArrayWithoutLastElement()
    {
        int[] array = { 1, 2, 3, 4 };
        int[] expected = { 1, 2, 3 };
        var result = array.Except(4);

        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Except_ValueIsFirstElement_ReturnsArrayWithoutFirstElement()
    {
        int[] array = { 1, 2, 3, 4 };
        int[] expected = { 2, 3, 4 };
        var result = array.Except(1);

        Assert.AreEqual(expected, result);
    }
}