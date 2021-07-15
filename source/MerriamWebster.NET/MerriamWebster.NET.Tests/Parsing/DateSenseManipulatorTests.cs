using MerriamWebster.NET.Parsing.Markup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class DateSenseManipulatorTests
    {
        [TestMethod]
        public void DateSenseManipulator_Remove_Full()
        {
            string input = "before 12th century{ds|t|1|a|1}";

            // ACT
            var output = new DateSenseManipulator().RemoveMarkup(input);

            // ASSERT
            output.ShouldBe("before 12th century");
        }

        [TestMethod]
        public void DateSenseManipulator_Replace_Full()
        {
            string input = "before 12th century{ds|t|1|a|1}";

            // ACT
            var output = new DateSenseManipulator().ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe("before 12th century, defined at sense (transitive) <b class=\"mw-b\">1</b>a(1)");
        }

        [TestMethod]
        public void DateSenseManipulator_Remove_NoLast()
        {
            string input = "14th century{ds|i|1||}";

            // ACT
            var output = new DateSenseManipulator().RemoveMarkup(input);

            // ASSERT
            output.ShouldBe("14th century");
        }

        [TestMethod]
        public void DateSenseManipulator_Replace_NoLast()
        {
            string input = "14th century{ds|i|1||}";

            // ACT
            var output = new DateSenseManipulator().ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe("14th century, defined at sense (intransitive) <b class=\"mw-b\">1</b>");
        }

        [TestMethod]
        public void DateSenseManipulator_Remove_NoVerb()
        {
            string input = "1818{ds||1|a|}";

            // ACT
            var output = new DateSenseManipulator().RemoveMarkup(input);

            // ASSERT
            output.ShouldBe("1818");
        }

        [TestMethod]
        public void DateSenseManipulator_Replace_NoVerb()
        {
            string input = "1818{ds||1|a|}";

            // ACT
            var output = new DateSenseManipulator().ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe("1818, defined at sense <b class=\"mw-b\">1</b>a");
        }

        [TestMethod]
        public void DateSenseManipulator_Replace_Empty()
        {
            string input = "1818{ds||||}";

            // ACT
            var output = new DateSenseManipulator().ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe("1818");
        }

        [TestMethod]
        public void DateSenseManipulator_Remove_Empty()
        {
            string input = "1818{ds||||}";

            // ACT
            var output = new DateSenseManipulator().RemoveMarkup(input);

            // ASSERT
            output.ShouldBe("1818");
        }

        [TestMethod]
        public void DateSenseManipulator_Remove_OnlySenseNumber()
        {
            string input = "circa 1530{ds||2||}";

            // ACT
            var output = new DateSenseManipulator().RemoveMarkup(input);

            // ASSERT
            output.ShouldBe("circa 1530");
        }

        [TestMethod]
        public void DateSenseManipulator_Replace_OnlySenseNumber()
        {
            string input = "circa 1530{ds||2||}";

            // ACT
            var output = new DateSenseManipulator().ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe("circa 1530, defined at sense <b class=\"mw-b\">2</b>");
        }
    }
}
