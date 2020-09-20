# MerriamWebster.NET
A .NET client for Merriam-Webster's api's. Only tested with the Spanish-English dictionary, but it should also work for the other api's that are available. 

For a list of available api's and in-depth documentation visit Merriam Webster's [Developer Centre](https://dictionaryapi.com/).

Requests to the Merriam-Webster api's are very simple, there is only one GET method, and all api's use the same format: 
> https://\<base address\>/_\<api name\>_/json/_\<entry\>_?key=myKey. 

Api requests are executed by the MerriamWebsterClient class. However, given the complex structure of the api response, it is highly recommended to use the EntryParser class instead and not use the MerriamWebsterClient directly. The EntryParser modifies the response into a format that is much easier to process further. EntryParser also contains one method: `GetAndParseAsync` which - surprise! - gets a result and parses it. The GetAndParseAsync method takes two parameters: the api name (all api's are available in the `Configuration` class) and the entry to get. 

## Usage
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
var mwConfig = Configuration.GetSection("MerriamWebster").Get<MerriamWebsterConfig>();
// this registers the HttpClient and IEntryParser
services.RegisterMerriamWebster(mwConfig);

// use IEntryParser on Spanish-English Dictionary api
var result = await entryParser.GetAndParseAsync(Configuration.SpanishEnglishDictionary, "ejemplo");
```
