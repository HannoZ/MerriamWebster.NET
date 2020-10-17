using MerriamWebster.NET.Parsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class MarkupRemoverTests
    {
        [TestMethod]
        public void MarkupRemover_Remove_B()
        {
            string input = "Some {b}bold{/b} text";
            
            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("Some bold text");
        }

        [TestMethod]
        public void MarkupRemover_Remove_It()
        {
            string input = "This is {it}some{/it} text";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("This is some text");
        }

        [TestMethod]
        public void MarkupRemover_Remove_Bc()
        {
            string input = "This is{bc} some text";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("This is some text");
        }

        [TestMethod]
        public void MarkupRemover_Remove_Sc()
        {
            string input = "This is {sc}some{/sc} text";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("This is some text");
        }

        [TestMethod]
        public void MarkupRemover_Remove_DxDef()
        {
            string input = "{bc}any of several domesticated {dx_def}see {dxt|domesticate:1||2}{/dx_def} or wild {d_link|gallinaceous|gallinaceous} birds {dx}compare {dxt|guinea fowl||}, {dxt|jungle fowl||}{/dx}";
            string expected = "any of several domesticated (see domesticate) or wild gallinaceous birds — compare guinea fowl, jungle fowl";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupRemover_Remove_Dxt_Test1()
        {
            string input = "{bc}a bird of any kind {dx}compare {dxt|waterfowl||}, {dxt|wildfowl||}";
            string expected = "a bird of any kind — compare waterfowl, wildfowl";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupRemover_Remove_Dxt_Test2()
        {
            string input = "{dx}compare {dxt|guinea fowl||}, {dxt|jungle fowl||}{/dx}";
            string expected = "— compare guinea fowl, jungle fowl";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        } 

        [TestMethod]
        public void MarkupRemover_Remove_Dxt_Test3()
        {
            string input = "{dxt|domesticate:1||2}";
            string expected = "domesticate";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupRemover_Remove_Dxef_Dx()
        {
            string input = "{bc}a small modern warship with shallow draft {dx_def}see {dxt|draft:1||8}{/dx_def} for coastal bombardment";
            string expected = "a small modern warship with shallow draft (see draft) for coastal bombardment";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupRemover_Remove_A_Link1()
        {
            string input = "{bc}the meat of {a_link|fowls} used as food";
            string expected = "the meat of fowls used as food";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupRemover_Remove_A_Link2()
        {
            string input = "{bc}one that {a_link|monitors} or is used in {a_link|monitoring}: such as";
            string expected = "one that monitors or is used in monitoring: such as";
          
            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupRemover_Remove_D_Link()
        {
            string input = "Manatees are {d_link|sirenians|sirenian} related to and resembling the {d_link|dugong|dugong} but differing most notably in the shape of the tail.";
            string expected = "Manatees are sirenians related to and resembling the dugong but differing most notably in the shape of the tail.";
          
            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);

        }

        [TestMethod]
        public void MarkupRemover_Remove_Mat()
        {
            string input = @"Middle English {it}foul{/it}, from Old English {it}fugel{/it}; akin to Old High German {it}fogal{/it} bird, and probably to Old English {it}flēogan{/it} to fly {ma}{mat|fly|}{/ma}";
            string expected = "Middle English foul, from Old English fugel; akin to Old High German fogal bird, and probably to Old English flēogan to fly — more at fly";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupRemover_Remove_Sx1()
        {
            string input = "a piece of {sx|araña deco||} text";
            string expected = "a piece of araña deco text";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupRemover_Remove_Sx2()
        {
            string input = "a piece of {sx|foo|bar|} text";
            string expected = "a piece of foo text";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupRemover_Remove_Sx3()
        {
            string input = "a piece of {sx|foo|bar|baz} text";
            string expected = "a piece of foo text";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }
    }
}
