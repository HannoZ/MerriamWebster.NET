using MerriamWebster.NET.Example.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MerriamWebster.NET.Results;
using MerriamWebster.NET.Results.Base;
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
            return View(new SearchRequestModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchRequestModel model)
        {
            if (_memCache.TryGetValue<ResultModel<Entry>>(model.Api + model.SearchTerm, out var result))
            {
                model.Result = result;
            }
            else
            {
                result = await _search.Search(model.Api, model.SearchTerm, model.ApiKey);
                model.Result = result;

                _memCache.Set(model.Api + model.SearchTerm, result);
            }

            return View(model);
        }

    }
}