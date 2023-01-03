using System;
using System.Collections.Generic;
using MerriamWebster.NET.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests
{
    [TestClass]
    public class CollectionExtensionsTests
    {
        [TestMethod]
        public void CollectionExtensions_HasValue()
        {
            ICollection<string> collection = new List<string>() {"foo"};
           
            // ACT
            var result = collection.HasValue();

            // ASSERT
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void CollectionExtensions_Null()
        {
            ICollection<string> collection = null;

            // ACT
            var result = collection.HasValue();

            // ASSERT
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void CollectionExtensions_IsEmpty()
        {
            ICollection<string> collection = new List<string>();

            // ACT
            var result = collection.HasValue();

            // ASSERT
            result.ShouldBeFalse();
        }
    }
}
