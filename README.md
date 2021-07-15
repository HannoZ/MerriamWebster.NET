![Build Test Package](https://github.com/HannoZ/MerriamWebster.NET/workflows/Build%20Test%20Package/badge.svg)

# MerriamWebster.NET
A .NET client wrapper and object parser for Merriam-Webster's APIs. Tested with the Spanish-English and collegiate dictionaries and a little bit with the medical dictionary. It will also work for all available APIs, but data structures that are specific to those APIs will not be available in the parsed objects. Response objects for those APIs were created based on documentation and some example json files. 

For a list of available APIs and in-depth documentation visit Merriam-Webster's [Developer Center](https://dictionaryapi.com/).

Requests to the Merriam-Webster APIs are very simple, there is only one GET method, and all APIs use the same format: 
> https://\<base address\>/_\<api name\>_/json/_\<entry\>_?key=myKey. 
> 
 (all api names are available in the `Configuration` class)

Api requests are executed by the MerriamWebsterClient class. To work with the response, it is highly recommended to use the ``EntryParser`` class. The EntryParser modifies the response into a format that is much easier to process further. 


***IMPORTANT*** 
As of version 2 of this libary, output of the EntryParser follows the official documentation, instead of returning a simple interpretation of the results. With the simple interpretation used in version 1.x it was not possible to parse and present the response data properly. 

## About the libary
The library contains three folders: Dto, Parsing and Response. The response folder contains classes to deserialize the API response, the Parsing folder contains a number of (internal) classes to parse the result, the Dto folder contains all the objects that are returned by the EntryParser. All objects are documented with the texts from the official documentation, along with the display guidance notes from the documentation.

The return type of the `EntryParser.Parse` method is a `ResultModel`. This model contains a collection of `Entry` objects. An entry is the central unit of a search result and contains a large number of properties that may, or may not, be present, depending on what was returned in the response. 
Here is where things become difficult, even in the parsed objects: the actual defining texts are found as follows: Entry > Definitions > SenseSequences > Senses > DefiningTexts
(see code sample below) 
The structure for senses is as follows: SenseSequenceSense > SenseBase > Sense/DividedSense . This structure is necessary because a sense sequence can contain any order of regular senses (Sense), parenthesized senses (a structure that has it's own nested senses), divided senses, and a number of others. 
Much more can be told about all the structures, but it's all explained very well in the offical documentation. 

## Parsing of Merriam-Webster markup. 
Many text properties can contain specific Merriam-Webster markup. Most of those properties are definied as `FormattedText`, a class that has three properties `RawText, Text, HtmlText`. The Text property has all markup removed, the HtmlText property has the markup replaced by HTML markup.
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
```
``` C#
// A sample class that uses the IMerriamWebsterClient and IEntryParser
public class MerriamWebsterSearch
{
    private readonly IMerriamWebsterClient _client;
    private readonly IEntryParser _entryParser;

    public MerriamWebsterSearch(IMerriamWebsterClient client, IEntryParser entryParser)
    {
        _client = client;
        _entryParser = entryParser;
    }

    public async Task<ResultModel> SearchAsync(string searchTerm)
    {
        var results = await _client.GetDictionaryEntry(Configuration.SpanishEnglishDictionary, searchTerm);
        
        return _entryParser.Parse(searchTerm, results);
    }
}
```
``` C#
public class Example
{
    private readonly MerriamWebsterSearch _search;

    // .. 

    public async Task GetResults(string searchTerm)
    {
        var result = await _search.SearchAsync(searchTerm);

        // when looping through the results like this, 
        // all senses with their defining texts appear in order 
        foreach (var entry in result.Entries)            
        {
            foreach (var definition in entry.Definitions)
            {
                foreach (var senseSequence in definition.SenseSequence)  
                {
                    // this is a simplification, in real applications 
                    // different types of sensens should be handled in different ways
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
    }
}
```
