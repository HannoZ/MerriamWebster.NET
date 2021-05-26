using MerriamWebster.NET.Parsing.Markup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class DirectLinkManipulatorTests
    {
        [TestMethod]
        public void ItalicLinkManipulator_Remove_LinkWithoutTarget()
        {
            string input = "This text contains a {d_link|direct link|} without target.";
            string expected = "This text contains a direct link without target.";

            var manipulator = new DirectLinkManipulator();

            // ACT
            var output = manipulator.RemoveMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void ItalicLinkManipulator_Replace_LinkWithoutTarget()
        {
            string input = "This text contains a {d_link|direct link|} without target.";
            string expected = "This text contains a <i class=\"mw-link mw-direct-link\">direct link</i> without target.";

            var manipulator = new DirectLinkManipulator();

            // ACT
            var output = manipulator.ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void DirectLinkManipulator_Remove_WithTarget()
        {
            string input = "Manatees are {d_link|sirenians|sirenian} related to and resembling the {d_link|dugong|dugong} but differing most notably in the shape of the tail.";
            string expected = "Manatees are sirenians related to and resembling the dugong but differing most notably in the shape of the tail.";

            var manipulator = new DirectLinkManipulator();

            // ACT
            var output = manipulator.RemoveMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void DirectLinkManipulator_Replace_WithTarget()
        {
            string input = "Manatees are {d_link|sirenians|sirenian} related to and resembling the {d_link|dugong|dugong} but differing most notably in the shape of the tail.";
            string expected = "Manatees are <i class=\"mw-link mw-direct-link\">sirenians</i> related to and resembling the <i class=\"mw-link mw-direct-link\">dugong</i> but differing most notably in the shape of the tail.";

            var manipulator = new DirectLinkManipulator();

            // ACT
            var output = manipulator.ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }
    }
}