using System;
using MerriamWebster.NET.Parsing.DictionaryEntryMembers;
using MerriamWebster.NET.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace MerriamWebster.NET.Tests.Parsing
{
    [TestClass]
    public class ArtworkDictionaryEntryMemberParserTests
    {
        [TestMethod]
        public void ArtworkDictionaryEntryMemberParser_Parse()
        {
            string source = @"{""art"":{
  ""artid"":""heart"",
  ""capt"":""heart 1a ...""
}
}";

            var target = new Entry();
            var parser = new ArtworkDictionaryEntryMemberParser();
            var art = EntryMemberParserTestsHelper.GetJsonProperty(source, "art");

            // ACT
            parser.Parse(art, target);

            // ASSERT
            target.Artwork.Caption.ShouldBe("heart 1a ...");
            target.Artwork.HtmlLocation.ShouldNotBe(null);
            target.Artwork.ImageLocation.ShouldNotBe(null);
        }

        [TestMethod]
        public void ArtworkDictionaryEntryMemberParser_Parse_TargetIsNull()
        {
            string source = @"{""art"":{
  ""artid"":""heart"",
  ""capt"":""heart 1a ...""
}
}";

            var parser = new ArtworkDictionaryEntryMemberParser();
            var art = EntryMemberParserTestsHelper.GetJsonProperty(source, "art");
            
            // ACT/ASSERT
            Should.Throw<ArgumentNullException>(() => parser.Parse(art, null));
        }

        [TestMethod]
        public void ArtworkDictionaryEntryMemberParser_Parse_SourceIsNotArt()
        {
            string source = @"{""abc"":{
  ""artid"":""heart"",
  ""capt"":""heart 1a ...""
}
}";

            var target = new Entry();
            var parser = new ArtworkDictionaryEntryMemberParser();
            var art = EntryMemberParserTestsHelper.GetJsonProperty(source, "abc");

            // ACT/ASSERT
            Should.Throw<ArgumentException>(()=>parser.Parse(art, target));
        }
    }
}