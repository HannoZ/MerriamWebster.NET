using MerriamWebster.NET.Parsing;
using MerriamWebster.NET.Parsing.Markup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class MarkupManipulatorTests
    {
        [TestMethod]
        public void MarkupManipulator_Remove_B()
        {
            string input = "Some {b}bold{/b} text";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("Some bold text");
        }

        [TestMethod]
        public void MarkupManipulator_Replace_B()
        {
            string input = "Some {b}bold{/b} text";

            // ACT
            var output = MarkupManipulator.ReplaceMarkupInString(input);

            // ASSERT
            output.ShouldBe("Some <b class=\"mw-b\">bold</b> text");
        }

        [TestMethod]
        public void MarkupManipulator_Remove_It()
        {
            string input = "This is {it}some{/it} text";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("This is some text");
        }

        [TestMethod]
        public void MarkupManipulator_Replace_It()
        {
            string input = "This is {it}some{/it} text";

            // ACT
            var output = MarkupManipulator.ReplaceMarkupInString(input);

            // ASSERT
            output.ShouldBe("This is <i class=\"mw-it\">some</i> text");
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Bc()
        {
            string input = "This is{bc} some text";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("This is some text");
        }

        [TestMethod]
        public void MarkupManipulator_Replace_Bc()
        {
            string input = "This is{bc} some text";

            // ACT
            var output = MarkupManipulator.ReplaceMarkupInString(input);

            // ASSERT
            output.ShouldBe("This is<b class=\"mw-bc\">:</b> some text");
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Wi()
        {
            string input = "A sergeant is {wi}above{/wi} a corporal.";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("A sergeant is above a corporal.");
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Sc()
        {
            string input = "This is {sc}some{/sc} text";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe("This is some text");
        }

        [TestMethod]
        public void MarkupManipulator_Remove_DxDef_Dx()
        {
            string input = "{bc}any of several domesticated {dx_def}see {dxt|domesticate:1||2}{/dx_def} or wild {d_link|gallinaceous|gallinaceous} birds {dx}compare {dxt|guinea-fowl||}, {dxt|jungle fowl||}{/dx}";
            string expected = "any of several domesticated (see domesticate:1) or wild gallinaceous birds — compare guinea-fowl, jungle fowl";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Dxt_Test4()
        {
            string input = "{bc}to like {dx_def}see {dxt|like:1|like:1|4}{/dx_def} an online post, comment, etc";
            string expected = "to like (see like:1) an online post, comment, etc";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Dxt_Test5()
        {
            string input = ".. light sources that may be described in terms of hue, lightness, and saturation {dx_def}see {dxt|saturation||4}{/dx_def} for objects ";
            string expected = ".. light sources that may be described in terms of hue, lightness, and saturation (see saturation) for objects ";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Dxt_Test1()
        {
            string input = "{bc}a bird of any kind {dx}compare {dxt|waterfowl||}, {dxt|wildfowl||}";
            string expected = "a bird of any kind — compare waterfowl, wildfowl";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Dxt_Test2()
        {
            string input = "{dx}compare {dxt|guinea fowl||}, {dxt|jungle fowl||}{/dx}";
            string expected = "— compare guinea fowl, jungle fowl";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Dxt_Test3()
        {
            string input = "{dxt|domesticate:1||2}";
            string expected = "domesticate:1";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }
        
        [TestMethod]
        public void MarkupManipulator_Remove_Et_link()
        {
            string input = "borrowed from New Latin {it}allīterātiōn-, allīterātiō,{/it} from Latin {it}ad-{/it} {et_link|ad-|ad-} + {it}lītera{/it} \"letter\" + {it}-ātiōn-, -ātiō{/it} {et_link|-ation|-ation} {ma}{mat|letter:1|}{/ma}";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            output.ShouldNotContain("et_link");
        }

        [TestMethod]
        public void MarkupManipulator_Replace_Et_link()
        {
            string input = "borrowed from New Latin {it}allīterātiōn-, allīterātiō,{/it} from Latin {it}ad-{/it} {et_link|ad-|ad-} + {it}lītera{/it} \"letter\" + {it}-ātiōn-, -ātiō{/it} {et_link|-ation|-ation} {ma}{mat|letter:1|}{/ma}";

            // ACT
            var output = MarkupManipulator.ReplaceMarkupInString(input);

            output.ShouldContain("mw-et-link");
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Dxef_Dx()
        {
            string input =
                "{bc}a small modern warship with shallow draft {dx_def}see {dxt|draft:1||8}{/dx_def} for coastal bombardment";
            string expected = "a small modern warship with shallow draft (see draft:1) for coastal bombardment";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Mat()
        {
            string input =
                "Middle English {it}foul{/it}, from Old English {it}fugel{/it}; akin to Old High German {it}fogal{/it} bird, and probably to Old English {it}flēogan{/it} to fly {ma}{mat|fly|}{/ma}";
            string expected =
                "Middle English foul, from Old English fugel; akin to Old High German fogal bird, and probably to Old English flēogan to fly — more at fly";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Sx1()
        {
            string input = "a piece of {sx|araña deco||} text";
            string expected = "a piece of araña deco text";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Sx2()
        {
            string input = "a piece of {sx|foo|bar|} text";
            string expected = "a piece of foo text";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Sx3()
        {
            string input = "a piece of {sx|foo|bar|baz} text";
            string expected = "a piece of foo text";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        

        [TestMethod]
        public void MarkupManipulator_ALinkWithDash()
        {
            string input = "{sx|fatigado||} {bc}{a_link|worn-out}, {a_link|tired}";
            string expected = "fatigado worn-out, tired";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);

        }

        [TestMethod]
        public void MarkupManipulator_Remove_Amp()
        {
            string input = "Southern {amp} Midland";
            string expected = "Southern & Midland";

            // ACT
            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Gloss()
        {
            string input = "an {wi}absence{/wi} {gloss}=lack{/gloss} of detail";
            string expected = "an absence [=lack] of detail";

            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Replace_Gloss()
        {
            string input = "an {wi}absence{/wi} {gloss}=lack{/gloss} of detail";
            string expected = "an <i class=\"mw-wi\">absence</i> <span class=\"mw-gloss\">[=lack]</span> of detail";

            var output = MarkupManipulator.ReplaceMarkupInString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Phrase()
        {
            string input = "{phrase}In the absence of{/phrase} reform {gloss}= without reform{/gloss}, progress will be slow.";
            string expected = "In the absence of reform [= without reform], progress will be slow.";

            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Replace_Phrase()
        {
            string input = "{phrase}In the absence of{/phrase} reform {gloss}= without reform{/gloss}, progress will be slow.";
            string expected = "<span class=\"mw-phrase\"><b><i>In the absence of</b></i></span> reform <span class=\"mw-gloss\">[= without reform]</span>, progress will be slow.";

            var output = MarkupManipulator.ReplaceMarkupInString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Qword()
        {
            string input = "Only five to six inches long and weighing less than two ounces, the elf owl is the smallest bird of prey in the world. Its bobbed tail, white \u0022eyebrows,\u0022 and {qword}absence{/qword} of ear tufts give this tiny mothlike predator its impish appearance.";
            string expected = "Only five to six inches long and weighing less than two ounces, the elf owl is the smallest bird of prey in the world. Its bobbed tail, white \u0022eyebrows,\u0022 and absence of ear tufts give this tiny mothlike predator its impish appearance.";

            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Replace_Qword()
        {
            string input = "Only five to six inches long and weighing less than two ounces, the elf owl is the smallest bird of prey in the world. Its bobbed tail, white \u0022eyebrows,\u0022 and {qword}absence{/qword} of ear tufts give this tiny mothlike predator its impish appearance.";
            string expected = "Only five to six inches long and weighing less than two ounces, the elf owl is the smallest bird of prey in the world. Its bobbed tail, white \u0022eyebrows,\u0022 and <i class=\"mw-qword\">absence</i> of ear tufts give this tiny mothlike predator its impish appearance.";

            var output = MarkupManipulator.ReplaceMarkupInString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Parahw()
        {
            string input = "Using {parahw}above{/parahw} as an Adjective or Noun";
            string expected = "Using above as an Adjective or Noun";

            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Replace_Parahw()
        {
            string input = "Using {parahw}above{/parahw} as an Adjective or Noun";
            string expected = "Using <i class=\"mw-parahw\">above</i> as an Adjective or Noun";

            var output = MarkupManipulator.ReplaceMarkupInString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Inf_Sup()
        {
            string input = "{bc}an ion NH{inf}4{/inf}{sup}+{/sup} derived from {a_link|ammonia} by combination with a hydrogen ion and ...";
            string expected = "an ion NH4+ derived from ammonia by combination with a hydrogen ion and ...";

            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }


        [TestMethod]
        public void MarkupManipulator_Replace_Inf_Sup()
        {
            string input = "an ion NH{inf}4{/inf}{sup}+{/sup} derived from {a_link|ammonia} by combination with a hydrogen ion and ...";
            string expected = "an ion NH<sub class=\"mw-inf\">4</sub><sup class=\"mw-sup\">+</sup> derived from <i class=\"mw-link mw-auto-link\">ammonia</i> by combination with a hydrogen ion and ...";

            var output = MarkupManipulator.ReplaceMarkupInString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Remove_Ld_RdQuo()
        {
            string input = "{ldquo}Can I e-mail you?{rdquo} {ldquo}Sure. Our e-mail address is \u2018comments {it}at{/it} Merriam - Webster dot com.\u2019{rdquo}";
            string expected = "“Can I e-mail you?” “Sure. Our e-mail address is \u2018comments at Merriam - Webster dot com.\u2019”";

            var output = MarkupManipulator.RemoveMarkupFromString(input);

            // ASSERT
            output.ShouldBe(expected);
        }

        [TestMethod]
        public void MarkupManipulator_Replace_Sc()
        {
            string input = "{sc}agree{/sc} {sc}concur{/sc} {sc}coincide{/sc} mean to come into or be in harmony regarding a matter of opinion.";
            string expected = "<span class=\"mw-sc\" style=\"font-variant: small-caps\">agree</span> <span class=\"mw-sc\" style=\"font-variant: small-caps\">concur</span> <span class=\"mw-sc\" style=\"font-variant: small-caps\">coincide</span> mean to come into or be in harmony regarding a matter of opinion.";

            var output = MarkupManipulator.ReplaceMarkupInString(input);

            // ASSERT
            output.ShouldBe(expected);
        }
    }
}
