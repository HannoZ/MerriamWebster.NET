using MerriamWebster.NET.Parsing.Markup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class MoreAtTargetManipulatorTests
    {
        [TestMethod]
        public void MoreAtTargetManipulator_Remove()
        {
            string input = "Middle English {it}foul{/it}, from Old English {it}fugel{/it}; akin to Old High German {it}fogal{/it} bird, and probably to Old English {it}flēogan{/it} to fly {ma}{mat|fly|}{/ma}";
            string expected = "Middle English {it}foul{/it}, from Old English {it}fugel{/it}; akin to Old High German {it}fogal{/it} bird, and probably to Old English {it}flēogan{/it} to fly — more at fly";

            var manipulator = new MoreAtTargetManipulator();

            // ACT
            var output = manipulator.RemoveMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MoreAtTargetManipulator_Replace()
        {
            string input = "Middle English {it}foul{/it}, from Old English {it}fugel{/it}; akin to Old High German {it}fogal{/it} bird, and probably to Old English {it}flēogan{/it} to fly {ma}{mat|fly|}{/ma}";
            string expected = "Middle English {it}foul{/it}, from Old English {it}fugel{/it}; akin to Old High German {it}fogal{/it} bird, and probably to Old English {it}flēogan{/it} to fly — more at <span class=\"mw-mat\">fly</span>";

            var manipulator = new MoreAtTargetManipulator();

            // ACT
            var output = manipulator.ReplaceMarkup(input);

            // ASSERT
            output.ShouldBe(expected);
        }
    }
}