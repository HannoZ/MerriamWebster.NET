using MerriamWebster.NET.Parsing.Markup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class DateSenseManipulatorTests
    {
        [TestMethod]
        public void DateSenseManipulator_Replace_Full()
        {
            string input = "before 12th century{ds|t|1|a|1}";

            // ACT
            var output = new DateSenseManipulator().RemoveMarkup(input);

            // ASSERT
            output.ShouldBe("before 12th century (transitive) 1a(1)");
        }

        [TestMethod]
        public void DateSenseManipulator_Replace_NoLast()
        {
            string input = "14th century{ds|i|1||}";

            // ACT
            var output = new DateSenseManipulator().RemoveMarkup(input);

            // ASSERT
            output.ShouldBe("14th century (intransitive) 1");
        }

        [TestMethod]
        public void DateSenseManipulator_Replace_NoVerb()
        {
            string input = "1818{ds||1|a|}";

            // ACT
            var output = new DateSenseManipulator().RemoveMarkup(input);

            // ASSERT
            output.ShouldBe("1818 1a");
        }

        [TestMethod]
        public void DateSenseManipulator_Replace_Empty()
        {
            string input = "1818{ds||||}}";

            // ACT
            var output = new DateSenseManipulator().RemoveMarkup(input);

            // ASSERT
            output.ShouldBe("1818");
        }
    }
}
