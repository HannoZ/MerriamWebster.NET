using MerriamWebster.NET.Example.Models;
using Microsoft.AspNetCore.Mvc;
using MerriamWebster.NET.Results;
using Microsoft.Extensions.Caching.Memory;
using MerriamWebster.NET.Parsing;

namespace MerriamWebster.NET.Example.Controllers
{
    public class HomeController(IMerriamWebsterSearch search, IJsonDocumentParser parser, IMemoryCache memCache) : Controller
    {
        private readonly IMerriamWebsterSearch _search = search;
        private readonly IMemoryCache _memCache = memCache;
        private readonly IJsonDocumentParser _parser = parser;

        public IActionResult Index()
        {
            return View(new SearchModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchModel model)
        {
            if (_memCache.TryGetValue<ResultModel>(model.Api + model.SearchTerm, out var result))
            {
                model.Result = result;
            }
            else
            {
                Configuration.Language = model.Api == Configuration.SpanishEnglishDictionary ? Language.Es : Language.En;
                result = await _search.Search(model.SearchTerm, model.Api, model.ApiKey);
                model.Result = result;

                _memCache.Set(model.Api + model.SearchTerm, result);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Load()
        {
            return View(new LoadModel());
        }

        [HttpPost]
        public IActionResult Load(LoadModel model)
        {
            Configuration.Language = model.Api == Configuration.SpanishEnglishDictionary ? Language.Es : Language.En;

            var resultModel = _parser.ParseSearchResult(model.Api, model.Response);
            resultModel.SearchText = model.SearchTerm;
            model.Result = resultModel;

            return View(model);
        }
    }
}