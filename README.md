![Build Test Package](https://github.com/HannoZ/MerriamWebster.NET/workflows/Build%20Test%20Package/badge.svg)

# MerriamWebster.NET
A .NET client wrapper and object parser for Merriam-Webster's APIs. Tested with the Spanish-English and collegiate dictionaries and a little bit with the medical dictionary. It will also work for all available APIs, but data structures that are specific to those APIs will not be available in the parsed objects. Response objects for those APIs were created based on documentation and some example json files. 

For a list of available APIs and in-depth documentation visit Merriam-Webster's [Developer Center](https://dictionaryapi.com/).

Requests to the Merriam-Webster APIs are very simple, there is only one GET method, and all APIs use the same format: 
> https://\<base address\>/_\<api name\>_/json/_\<entry\>_?key=myKey. 
> 
 (all api names are available in the `Configuration` class)

Api requests are executed by the MerriamWebsterClient class. To work with the response, it is highly recommended to use the ``MerriamWebsterSearch`` class. The MerriamWebsterSearch class makes the call to the MW api and modifies the response into a format that is much easier to process further. 

***IMPORTANT*** 
Version 3 of this library was rewritten almost entirely, it now uses the System.Text.Json methods to parse the API results directly (instead of deserializing to classes using Newtonsoft.Json) and is super-fast! 

## About the libary
The library contains two main folders: Parsing and Results. The Parsing folder contains a large number of (internal) classes to parse the result, the Results folder contains all the objects that are returned by MerriamWebsterSearch. All objects are documented with the texts from the official documentation, along with the display guidance notes from the documentation.

The return type of the MerriamWebsterSearch search methods is a `ResultModel<Entry>`. This model contains a collection of `Entry` objects. An entry is the central unit of a search result and contains a large number of properties that may, or may not, be present, depending on what was returned in the response. As of version 3 of this library, some APIs return a more specific type of entry with additional properties that are only present for a certain API. Spanish-English dictionary: ``SpanishEnglishEntry``, Medical dictionary: ``MedicalEntry``.

Now comes the difficult part, even in the parsed objects: the actual defining texts are found as follows: Entry > Definitions > SenseSequences > Senses > DefiningTexts
(see code sample below) 
The structure for senses is as follows: SenseSequenceSense > SenseBase > Sense/DividedSense . This structure is necessary because a sense sequence can contain any order of regular senses (Sense), parenthesized senses (a structure that has it's own nested senses), divided senses, and a number of others. 
Much more can be told about all the structures, but it's all explained very well in the offical documentation. 
Note however, that all main defining texts are also found in the ``Shortdefs`` property, which may already be sufficient for simple scenario's. 

## Parsing of Merriam-Webster markup. 
Many text properties can contain specific Merriam-Webster markup. Most of those properties are definied as `FormattedText`, a class that has three properties `RawText, Text, HtmlText`. The Text property has all markup removed, the HtmlText property has the markup replaced by HTML markup.
For example this text: 
> an ion NH{inf}4{/inf}{sup}+{/sup} derived from {a_link|ammonia} by combination with a hydrogen ion and ...

Is converted to 
> an ion NH<sub class="mw-inf">4</sub><sup class="mw-sup">+</sup> derived from <i class="mw-link mw-auto-link">ammonia</i> by combination with a hydrogen ion and ...

A MW markup tag is either replaced directly by an HTML tag *(eg. {it} is replaced by \<i>)*, or wrapped by a \<span> tag *(eg. {bc} is replaced by \<span>\<b>:\</b>\</span> to render a bold colon)*. For all replacements a CSS class is assigned in the format 'mw-{tagname}' to support additional and/or custom styling *(eg. \<i class="mw-it">, \<i class="mw-qword">)*. Replacements for links get two classes 'mw-link' and a class for the specific link type *(eg. \<i class="mw-link mw-auto-link">)*
    
The HTML replacements follow the display guidelines that are found in the API documentation. Also note that some markup only needs to be removed or replaced with other non-HTML characters *(eg. {ldquo} is replaced by &#8220; )*.
    
## Usage (.NET Core) 
The configuration / services registration supports 1 api key. 
The MerriamWebsterSearch class also contains overloads where a specific api key can be provided
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
    // this registers the IMerriamWebsterClient and MerriamWebsterSearch
    services.RegisterMerriamWebster(mwConfig);
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
For a fully working example on how to use the library and how to render the results, see the MerriamWebster.NET.Example project (based on the standard ASP.NET Core MVC template)

## A note on serialization/deserialization
Serialization and deserialization only works with the Json.NET library. The System.Text.Json classes don't support deserialization of interfaces (for example the DefiningTexts property on the SenseBase class is a collection of IDefiningText). 
Serialization and deserialization has been tested with the following serializer settings: 
``` C#
private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
{
    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
    TypeNameHandling = TypeNameHandling.Objects,
    NullValueHandling = NullValueHandling.Ignore
};

```
Serialization settings are also required when the ResultModel is returned by a WebApi method, else a lot of information will be missing in the JSON response (all defining texts for example)
