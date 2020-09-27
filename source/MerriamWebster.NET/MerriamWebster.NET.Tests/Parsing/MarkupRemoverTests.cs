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
        public void MarkupRemover_Remove_Wi()
        {
            string input = "A sergeant is {wi}above{/wi} a corporal.";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("A sergeant is above a corporal.");
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

        [TestMethod]// TODO
        public void MarkupRemover_Remove_DxDef()
        {
            string input = "This is {dx_def}some{/dx_def} text";

            //string input = @"{bc}any of several domesticated {dx_def}see {dxt|domesticate:1||2}{/dx_def} or wild {d_link|gallinaceous|gallinaceous}
            //    birds {dx}compare {dxt|guinea fowl||}, {dxt|jungle fowl||}{/dx}";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("This is (some) text");

            //string expected = @"any of several domesticated (see 'domesticate:1||2')
            //    or wild gallinaceous|gallinaceous
            //    birds [compare 'guinea fowl', 'jungle fowl']";
        }

        [TestMethod]
        public void MarkupRemover_Remove_A_Link()
        {
            string input = "{bc}the meat of {a_link|fowls} used as food";

            // ACT
            var output = MarkupRemover.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("the meat of fowls used as food");
        }
    }
}
