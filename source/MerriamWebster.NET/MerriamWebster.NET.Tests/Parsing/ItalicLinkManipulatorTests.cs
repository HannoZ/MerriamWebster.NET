using MerriamWebster.NET.Parsing.Markup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class ItalicLinkManipulatorTests
    {
        [TestMethod]
        public void ItalicLinkManipulator_Remove_LinkWithoutTarget()
        {
            string input = "This text contains an {i_link|italic link|} without target.";
            string expected = "This text contains an italic link without target.";

            var manipulator = new ItalicLinkManipulator();

            // ACT
            var output = manipulator.RemoveMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void ItalicLinkManipulator_Replace_LinkWithoutTarget()
        {
            string input = "This text contains an {i_link|italic link|} without target.";
            string expected = "This text contains an <i class=\"mw-link mw-italic-link\">italic link</i> without target.";

            var manipulator = new ItalicLinkManipulator();

            // ACT
            var output = manipulator.ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void ItalicLinkManipulator_Remove_LinkWithTarget()
        {
            string input = "This text contains an {i_link|italic link|target} with target.";
            string expected = "This text contains an italic link with target.";

            var manipulator = new ItalicLinkManipulator();

            // ACT
            var output = manipulator.RemoveMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void ItalicLinkManipulator_Replace_LinkWithTarget()
        {
            string input = "This text contains an {i_link|italic link|target} with target.";
            string expected = "This text contains an <i class=\"mw-link mw-italic-link\">italic link</i> with target.";

            var manipulator = new ItalicLinkManipulator();

            // ACT
            var output = manipulator.ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }
    }
}