using MerriamWebster.NET.Example.Models;
using Microsoft.AspNetCore.Mvc;
using MerriamWebster.NET.Results;
using Microsoft.Extensions.Caching.Memory;

namespace MerriamWebster.NET.Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly MerriamWebsterSearch _search;
        private readonly IMemoryCache _memCache;

        public HomeController(MerriamWebsterSearch search, IMemoryCache memCache)
        {
            _search = search;
            _memCache = memCache;
        }

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
                result = await _search.Search(model.Api, model.SearchTerm, model.ApiKey);
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
            var resultModel = _search.ParseApiResponse(model.Api, model.SearchTerm, model.Response);
            model.Result = resultModel;

            return View(model);
        }
    }
}