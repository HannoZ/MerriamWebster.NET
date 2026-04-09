![Build Test Package](https://github.com/HannoZ/MerriamWebster.NET/workflows/Build%20Test%20Package/badge.svg)

# MerriamWebster.NET
A super-fast, lightweight .NET client wrapper and object parser for Merriam-Webster's APIs. Tested with the Spanish-English and collegiate dictionaries and a little bit with the medical dictionary. 
> _Note:_ Parsing will work for all other available APIs, but some data structures that are specific to those APIs may not be available in the parsed objects. Response objects for those APIs were created based on documentation and some example json files. 

For a list of available APIs and in-depth documentation of the API, visit Merriam-Webster's [Developer Center](https://dictionaryapi.com/).

## About the library

Requests to the Merriam-Webster APIs are very simple: there is only one GET method, and all APIs use the same format:
> https://www.dictionaryapi.com/api/v3/references/<apiName\>/json/<searchTerm\>?key=myKey
>
(all API names are available in the `Configuration` class)

Api requests are executed by the `MerriamWebsterClient` class. To work with the response, it is highly recommended to use the `MerriamWebsterSearch` class. `MerriamWebsterSearch` makes the call to the MW API and transforms the response into a format that is much easier to process further.

The configuration supports a default `ApiName` via `MerriamWebsterConfig.ApiName`. When `api` is not supplied to `IMerriamWebsterSearch.Search`, the configured default API name is used.

The library contains two main folders: Parsing and Results. The Parsing folder contains a large number of (internal) classes to parse the result, and the Results folder contains all the objects that are returned by `MerriamWebsterSearch`. All objects are documented with the texts from the official documentation, along with the display guidance notes from the documentation.

The return type of the MerriamWebsterSearch search methods is a `ResultModel`. This model contains a collection of `Entry` objects. An entry is the central unit of a search result and contains a large number of properties that may, or may not, be present, depending on what was returned in the response and which API was used.
`ResultModel.RawResponse` is only populated when `MerriamWebsterConfig.IncludeRawResponse` is enabled, which is useful for debugging raw API payloads.

For most applications, the simplest way to use the library is to read the short definitions directly. The `ResultModel` adds a convenience property named `ShortDefinitions` that flattens all entry short definitions into a single collection:

```csharp
public async Task GetResults(string searchTerm)
{
    var result = await _mwSearch.Search(searchTerm);

    foreach (var shortDef in result.ShortDefinitions)
    {
        Console.WriteLine(shortDef);
    }
}
```

If you want to preserve the short definitions per entry, use `Entry.ShortDefs` or `Entry.Summary`:

```csharp
foreach (var entry in result.Entries)
{
    Console.WriteLine(entry.Summary);
    foreach (var shortDef in entry.ShortDefs)
    {
        Console.WriteLine(shortDef);
    }
}
```

For advanced scenarios, the full parsed structure is available too. In that case the actual defining texts are found as follows: Entry > Definitions > SenseSequence > Senses > DefiningTexts
(see code sample below).
The structure for senses is as follows: SenseSequence > SenseBase > Sense/DividedSense. This structure is necessary because a sense sequence can contain any order of regular senses (`Sense`), parenthesized senses (a structure that has its own nested senses), divided senses, and a number of others.
Much more can be said about the structures, but the official documentation explains them in detail.

## Usage 
The configuration / services registration supports 1 api key and a default API name via `ApiName`.
The `MerriamWebsterSearch` class exposes a single `Search` method where both `api` and `apiKey` are optional values.
```JSON
/* appsettings.json */
{
  "MerriamWebster": {
    "ApiKey": "00000000-0000-0000-0000-000000000000",
    "ApiName": "collegiate"
  }
}
```

``` C#
// in Program.cs (minimal hosting)
using MerriamWebster.NET;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var mwConfig = builder.Configuration.GetSection("MerriamWebster").Get<MerriamWebsterConfig>()
    ?? new MerriamWebsterConfig();

builder.Services.RegisterMerriamWebster(mwConfig);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
```

``` C#
public class Example
{
    private readonly IMerriamWebsterSearch _search;

    // .. 

    public async Task GetResults(string searchTerm)
    {
        // execute a search request, using the default api and api key from configuration
        var result = await _search.Search(searchTerm);

        // when looping through the results like this,
        // all senses with their defining texts appear in order
        foreach (var entry in result.Entries)
        {
            foreach (var definition in entry.Definitions)
            {
                foreach (var senseSequence in definition.SenseSequence)
                {
                    // this is a simplification; in real applications
                    // different types of senses should be handled in different ways
                    foreach (var sense in senseSequence.Senses.OfType<Sense>())
                    {
                        foreach (var definingText in sense.DefiningTexts)
                        {
                            string text = definingText.MainText;
                        }
                    }
                }
            }
        }

        // search using an api that is not the default api in configuration
        var spanishResult = await _search.Search(searchTerm, Configuration.SpanishEnglishDictionary);
    }
}
```

For a fully working example on how to use the library and how to render the results, see the `MerriamWebster.NET.Example` demo project (based on the standard ASP.NET Core MVC template). The demo site is also available on https://merriam-webster-net-example.azurewebsites.net/ (it runs on free infrastructure which may take a minute to start up)

## Advanced scenario: Parsing of Merriam-Webster markup. 
Many text properties can contain specific Merriam-Webster markup. Most of those properties are defined as `FormattedText`, a class that has three properties: `RawText`, `Text`, and `HtmlText`. The `Text` property has all markup removed, and the `HtmlText` property has the markup replaced by HTML markup.
For example this text: 
> an ion NH{inf}4{/inf}{sup}+{/sup} derived from {a_link|ammonia} by combination with a hydrogen ion and ...

Is converted to 
> an ion NH<sub class="mw-inf">4</sub><sup class="mw-sup">+</sup> derived from <i class="mw-link mw-auto-link">ammonia</i> by combination with a hydrogen ion and ...

A MW markup tag is either replaced directly by an HTML tag *(eg. {it} is replaced by \<i>)*, or wrapped by a \<span> tag *(eg. {bc} is replaced by \<span>\<b>:\</b>\</span> to render a bold colon)*. For all replacements a CSS class is assigned in the format 'mw-{tagname}' to support additional and/or custom styling *(eg. \<i class="mw-it">, \<i class="mw-qword">)*. Replacements for links get two classes 'mw-link' and a class for the specific link type *(eg. \<i class="mw-link mw-auto-link">)*
    
The HTML replacements follow the display guidelines that are found in the API documentation. Also note that some markup only needs to be removed or replaced with other non-HTML characters *(eg. {ldquo} is replaced by &#8220; )*.
    

## A note on serialization/deserialization
Serialization and deserialization now works with both `Json.NET` and `System.Text.Json` for the library’s polymorphic `IDefiningText` values. The library includes a custom `JsonConverter` for `IDefiningText`, so `ResultModel` can be serialized and deserialized by `System.Text.Json` without requiring additional converter configuration for the built-in defining text types.

`Json.NET` serialization and deserialization has been tested with the following serializer settings: 
``` C#
private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
{
    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
    TypeNameHandling = TypeNameHandling.Objects,
    NullValueHandling = NullValueHandling.Ignore
};

```
> _Note:_ Serialization settings are also required when the ResultModel is returned by a WebApi method to a client (Angular web app for example, though in that case it may be a better idea to transform the ResultModel in the backend into objects that can be used by the client directly), else a lot of information will be missing in the JSON response (all defining texts for example)
