using MerriamWebster.NET.Parsing.Content;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using MerriamWebster.NET.Results;

namespace MerriamWebster.NET.Parsing
{
    /// <summary>
    /// Contains methods to get a result from the API and parse the raw data into an <see cref="ResultModel"/>.
    /// </summary>
    public class EntryParser : IEntryParser
    {
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        private static readonly List<IContentParser> ContentParsers;

        
        static EntryParser()
        {
            var types = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(IContentParser).IsAssignableFrom(type) && !type.IsInterface)
                .ToList();

            ContentParsers = new List<IContentParser>(types.Select(type => (IContentParser)Activator.CreateInstance(type)));
        }

        /// <inheritdoc />
        public ResultModel Parse(string searchTerm, IEnumerable<Response.MwDictionaryEntry> results)
        {
            return Parse(searchTerm, results, ParseOptions.Default);
        }

        /// <inheritdoc />
        public ResultModel Parse(string searchTerm, IEnumerable<Response.MwDictionaryEntry> results, ParseOptions options)
        {
#if NET7_0_OR_GREATER
            ArgumentException.ThrowIfNullOrEmpty(searchTerm, nameof(searchTerm));
#else
            ArgumentNullException.ThrowIfNull(searchTerm, nameof(searchTerm));
#endif
            options ??= ParseOptions.Default;

            var resultModel = new ResultModel
            {
                SearchText = searchTerm.ToLowerInvariant(),
                RawResponse = JsonConvert.SerializeObject(results, SerializerSettings)
            };

            foreach (var result in results)
            {
                var entry = CreateEntry(result, options);

                // parse definitions
                foreach (var def in result.Definitions)
                {
                    var definition = new Definition
                    {
                        VerbDivider = def.VerbDivider
                    };

                    var senseParser = new SenseParser(def, entry.Metadata.Language, options);
                    senseParser.Parse(definition);

                    if (def.Sls.Any())
                    {
                        definition.SubjectStatusLabels = new List<Label>();
                        foreach (var label in def.Sls)
                        {
                            definition.SubjectStatusLabels.Add(label);
                        }
                    }

                    entry.Definitions.Add(definition);
                }

                resultModel.Entries.Add(entry);
                
                
            }

            return resultModel;
        }

        private static Entry CreateEntry(Response.MwDictionaryEntry sourceEntry, ParseOptions options)
        {
            var entry = new Entry
            {
                PartOfSpeech = sourceEntry.FunctionalLabel ?? string.Empty,
                ShortDefs = sourceEntry.Shortdefs,
                Homograph = sourceEntry.Homograph.GetValueOrDefault(),
                Date = sourceEntry.Date,
            };
            
            if (sourceEntry.GeneralLabels.Any())
            {
                entry.GeneralLabels = new List<Label>();
                foreach (var generalLabel in sourceEntry.GeneralLabels)
                {
                    entry.GeneralLabels.Add(generalLabel);
                }
            }

            if (sourceEntry.SubjectStatusLabels.Any())
            {
                entry.SubjectStatusLabels = new List<Label>();
                foreach (var subjectStatusLabel in sourceEntry.SubjectStatusLabels)
                {
                    entry.SubjectStatusLabels.Add(subjectStatusLabel);
                }
            }
            
            // let all IContentParser implementations do their job 
            foreach (var contentParser in ContentParsers)
            {
                contentParser.Parse(sourceEntry, entry, options);
            }

            return entry;
        }

    }
}