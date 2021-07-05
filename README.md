![Build Test Package](https://github.com/HannoZ/MerriamWebster.NET/workflows/Build%20Test%20Package/badge.svg)

# MerriamWebster.NET
A .NET client wrapper and object parser for Merriam-Webster's APIs. Tested with the Spanish-English dictionary and a little bit with the collegiate and medical dictionaries. It should work for all available APIs, though perhaps not all data will be deserialized properly. Response objects for those APIs are created based on documentation and some example json files. 

For a list of available APIs and in-depth documentation visit Merriam-Webster's [Developer Center](https://dictionaryapi.com/).

Requests to the Merriam-Webster APIs are very simple, there is only one GET method, and all APIs use the same format: 
> https://\<base address\>/_\<api name\>_/json/_\<entry\>_?key=myKey. 

Api requests are executed by the MerriamWebsterClient class. However, given the complex structure of the api response, it is highly recommended to use the EntryParser class instead and not use the MerriamWebsterClient directly. The EntryParser modifies the response into a format that is much easier to process further. EntryParser also contains one method: `GetAndParseAsync` which - surprise! - gets a result and parses it. The GetAndParseAsync method takes two parameters: the api name (all api's are available in the `Configuration` class) and the entry to get. 

***Important*** 
The EntryParser was developed primarily for the Spanish-English dictionary api, therefore not all available information is parsed. The ``RawResponse`` property on the ``EntryModel`` class contains the raw response from the API in case you need to get additional data from the response. You can also open an issue with a request for specific data. Parsing data from raw response to the DTO classes will be implemented step-by-step in future updates.

## Parsing of Merriam-Webster markup into HTML markup. 
In version 1.7, a new property has been added to the Sense and Example dto classes: `HtmlText`. This property contains the original text, but with the MW-specific markup replaced by corresponding HTML markup. 
For example this text: 
> an ion NH{inf}4{/inf}{sup}+{/sup} derived from {a_link|ammonia} by combination with a hydrogen ion and ...

Is converted to 
> an ion NH<sub class="mw-inf">4</sub><sup class="mw-sup">+</sup> derived from <i class="mw-link mw-auto-link">ammonia</i> by combination with a hydrogen ion and ...

A MW markup tag is either replaced directly by an HTML tag *(eg. {it} is replaced by \<i>)*, or wrapped by a \<span> tag *(eg. {bc} is replaced by \<span>\<b>:\</b>\</span> to render a bold colon)*. For all replacements a CSS class is assigned in the format 'mw-{tagname}' to support additional and/or custom styling *(eg. \<i class="mw-it">, \<i class="mw-qword">)*. Replacements for links get two classes 'mw-link' and a class for the specific link type *(eg. \<i class="mw-link mw-auto-link">)*
    
The HTML replacements follow the display guidelines that are found in the API documentation. Also note that some markup only needs to be removed or replaced with other non-HTML characters *(eg. {ldquo} is replaced by &#8220; )*.
    
## Usage (.NET Core) 
```JSON
/* appsettings.json */
{
"MerriamWebster": {
    "ApiKey": "00000000-0000-0000-0000-000000000000"
  } 
}
```
``` C#
// in Startup class
using MerriamWebster.NET;
..

public Startup(IConfiguration configuration, IWebHostEnvironment env)
{
    Configuration = configuration;
    Env = env;
}

public IConfiguration Configuration { get; }
..

public void ConfigureServices(IServiceCollection services)
{
    ..
    var mwConfig = Configuration.GetSection("MerriamWebster").Get<MerriamWebsterConfig>();
    // this registers the HttpClient and IEntryParser
    services.RegisterMerriamWebster(mwConfig);
}

// use an injected IEntryParser instance on Spanish-English Dictionary api
var result = await entryParser.GetAndParseAsync(Configuration.SpanishEnglishDictionary, "ejemplo");
```
