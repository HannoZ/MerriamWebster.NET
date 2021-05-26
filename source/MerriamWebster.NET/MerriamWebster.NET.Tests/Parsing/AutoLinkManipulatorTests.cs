using MerriamWebster.NET.Parsing.Markup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class AutoLinkManipulatorTests
    {
        [TestMethod]
        public void AutoLinkManipulator_Remove_1()
        {
            string input = "the meat of {a_link|fowls} used as food";
            string expected = "the meat of fowls used as food";

            var manipulator = new AutoLinkManipulator();

            // ACT
            var output = manipulator.RemoveMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void AutoLinkManipulator_Remove_2()
        {
            string input = "one that {a_link|monitors} or is used in {a_link|monitoring}: such as";
            string expected = "one that monitors or is used in monitoring: such as";

            var manipulator = new AutoLinkManipulator();

            // ACT
            var output = manipulator.RemoveMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void AutoLinkManipulator_Remove_3()
        {
            string input = "{a_link|yesteryear}, {a_link|long ago}";
            string expected = "yesteryear, long ago";

            var manipulator = new AutoLinkManipulator();

            // ACT
            var output = manipulator.RemoveMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void AutoLinkManipulator_Replace_1()
        {
            string input = "the meat of {a_link|fowls} used as food";
            string expected = "the meat of <i class=\"mw-link mw-auto-link\">fowls</i> used as food";

            var manipulator = new AutoLinkManipulator();

            // ACT
            var output = manipulator.ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void AutoLinkManipulator_Replace_2()
        {
            string input = "one that {a_link|monitors} or is used in {a_link|monitoring}: such as";
            string expected = "one that <i class=\"mw-link mw-auto-link\">monitors</i> or is used in <i class=\"mw-link mw-auto-link\">monitoring</i>: such as";

            var manipulator = new AutoLinkManipulator();

            // ACT
            var output = manipulator.ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void AutoLinkManipulator_Replace_3()
        {
            string input = "{a_link|yesteryear}, {a_link|long ago}";
            string expected = "<i class=\"mw-link mw-auto-link\">yesteryear</i>, <i class=\"mw-link mw-auto-link\">long ago</i>";

            var manipulator = new AutoLinkManipulator();

            // ACT
            var output = manipulator.ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }
    }
}