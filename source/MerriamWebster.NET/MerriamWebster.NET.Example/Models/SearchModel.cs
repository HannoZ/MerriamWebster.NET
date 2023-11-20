using MerriamWebster.NET.Results;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MerriamWebster.NET.Example.Models
{
    public class SearchModel
    {
        public string ApiKey { get; set; }
        public string Api { get; set; }
        public string SearchTerm { get; set; }

        public List<SelectListItem> Apis = new List<SelectListItem>
        {
            new("Collegiate dictionary", Configuration.CollegiateDictionary),
            new("Collegiate thesaurus", Configuration.CollegiateThesaurus),
            new("Medical dictionary", Configuration.MedicalDictionary),
            new("Spanish-English dictionary", Configuration.SpanishEnglishDictionary)
        };

        public ResultModel Result { get; set; }
    }

    public class LoadModel : SearchModel
    {
        public string Response { get; set; }
    }
}
