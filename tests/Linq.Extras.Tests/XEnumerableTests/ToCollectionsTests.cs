﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Linq.Extras.Tests.XEnumerableTests
{
    public class ToCollectionsTests
    {
        [Fact]
        public void ToQueue_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<ArgumentNullException>(() => source.ToQueue());
            ex.ParamName.Should().Be("source");
        }

        [Fact]
        public void ToQueue_Returns_A_Queue_With_The_Same_Items_As_Source()
        {
            var items = new[] { 4, 8, 15, 16, 23, 42 };
            var source = items.ForbidMultipleEnumeration();
            var queue = source.ToQueue();
            queue.Should().Equal(items);
        }

        [Fact]
        public void ToStack_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<ArgumentNullException>(() => source.ToStack());
            ex.ParamName.Should().Be("source");
        }

        [Fact]
        public void ToStack_Returns_A_Stack_With_The_Same_Items_As_Source()
        {
            var items = new[] { 4, 8, 15, 16, 23, 42 };
            var source = items.ForbidMultipleEnumeration();
            var stack = source.ToStack();
            stack.Should().Equal(items.Reverse());
        }

        [Fact]
        public void ToHashSet_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<ArgumentNullException>(() => source.ToHashSet());
            ex.ParamName.Should().Be("source");
        }

        [Fact]
        public void ToHashSet_Returns_A_HashSet_With_The_Same_Items_As_Source()
        {
            var items = new[] { 4, 8, 15, 16, 23, 42 };
            var source = items.ForbidMultipleEnumeration();
            var hashSet = source.ToHashSet();
            hashSet.Should().Equal(items);
        }

        [Fact]
        public void ToHashSet_Uses_The_Provided_Comparer()
        {
            var items = new[] { 4, -8, 15, 16, -23, 42 };
            var source = items.ForbidMultipleEnumeration();
            var comparer = XEqualityComparer<int>.By(Math.Abs);
            var hashSet = source.ToHashSet(comparer);
            hashSet.Should().Equal(items, comparer.Equals);
        }

        [Fact]
        public void ToLinkedList_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<ArgumentNullException>(() => source.ToLinkedList());
            ex.ParamName.Should().Be("source");
        }

        [Fact]
        public void ToLinkedList_Returns_A_LinkedList_With_The_Same_Items_As_Source()
        {
            var items = new[] { 4, 8, 15, 16, 23, 42 };
            var source = items.ForbidMultipleEnumeration();
            var linkedList = source.ToLinkedList();
            linkedList.Should().Equal(items);
        }

        [Fact]
        public void ToArray_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<ArgumentNullException>(() => source.ToArray(42));
            ex.ParamName.Should().Be("source");
        }

        [Fact]
        public void ToArray_Returns_An_Array_With_The_Same_Items_As_Source()
        {
            var items = new[] { 4, 8, 15, 16, 23, 42 };
            var source = items.ForbidMultipleEnumeration();
            var array = source.ToArray(items.Length);
            array.Should().Equal(items);
        }

        [Fact]
        public void ToList_Throws_If_Source_Is_Null()
        {
            IEnumerable<int> source = null;
            // ReSharper disable once AssignNullToNotNullAttribute
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            var ex = Assert.Throws<ArgumentNullException>(() => source.ToList(42));
            ex.ParamName.Should().Be("source");
        }

        [Fact]
        public void ToList_Returns_A_List_With_The_Same_Items_As_Source()
        {
            var items = new[] { 4, 8, 15, 16, 23, 42 };
            var source = items.ForbidMultipleEnumeration();
            var list = source.ToList(items.Length);
            list.Should().Equal(items);
        }
    }
}
