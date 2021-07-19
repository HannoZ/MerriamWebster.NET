2.0.1 Some properties on (un)defined-run ons were not parsed yet, this has been corrected. Added a utility extension method for collections `HasValue` to safely check if a collection is not empty (because the default value for most collections is `null`) 

2.0 A new major version! The structure of the parsed objects has completely been changed and now follows the original structure. This had made those classes more complex but it's the only way to present all data as it was intended by the makers. More information can be found in the readme

1.9 Huge serialization update, all documented structures that may appear in the collegiate dictionary should now be deserialized properly. ``BiographicalNameWrap`` and ``CalledAlsoNote`` are removed, they are now deserialized as ``DefiningText``.
The next step will be to extend the parser to make all information available on the parsed result classes. 

1.8 This release contains a number of improvements
- Removed filter on search term in entry parser, all results will now be returned. filtering can be applied on the result model by the caller
- Added parsing of quotes
- Fixed deserialization of entries that contain a 'ca' structure inside the 'dt' structure (which occurs frequently in the medical api)
- Implemented deserialization of BiographicalNameWrap (bnw)
- Improved exception handling when deserialization fails due to missing implementation
- Added parsing of Date property
- Added some missing XML documentation

1.7.1 Added new property ``AdditionalInformation`` to the Sense dto class. This property will contain the content of the 'sls' property of the sense response object. See chapter 2.7.3 SUBJECT/STATUS LABELS of the official documentation for further info. 

1.7 New feature! Besides (improved) MW-specific markup removal, the markup is now also replaced with HTML markup. Implemented in Sense and Example objects. 

1.6.1 Extended XML documentation. Added a new property ``RawResponse`` to the ``EntryModel`` class that contains the raw API response.

1.6 Enabled XML doc generation so existing documentation is actually visible

1.5.2 Some internal changes in the way that markup is removed from text

1.5.1 Removed dependency on Microsoft.Extensions.DependencyInjection package

1.5.0 Updated dependencies to .NET 5

1.4.3 Fix another issue in removing markup, that occurred when target contained multiple words (eg. {a_link|long ago}) 

1.4.2 Fix issue in removing markup when a link target contains a special character (eg. {a_link|worn-out}) 

1.4.1 Improved markup removal, dx_def, dx, dx_ety, ma/mat, sx, d_link, i_link, et_link are now all removed properly

1.4 Updated .NET Core Nuget packages to version 3.1.9

1.3 A major update, may break existing code (renamed some existing properties). Many response classes and properties were added, based on available documentation. Some of those new items are also parsed and returned on the DTO classes, but most are only deserialized but not parsed (so you won't see them on DTO classes). 
A new data structure for _DefiningText_ ('dt') elements was discovered in the JSON example for the Learner's Dictionary, which caused deserializing to fail. This structure has been applied to the response classes so deserialization succeeds again. 
Documentation has been added to many response classes.

1.2.1 This version contains some improvements to parsing as well as some small optimizations
- CrossReferences are now parsed (on Entry and Sense). A cross reference points to a different entry that contains more detailed information
- Additional results ('defined run-ons') are now placed in a separate collection, instead of being added to the Entries collection
- A definition for a verb that contains a 'verb divider' (eg. 'transitive verb') is now added as a separate Entry to the Entries collection
- 'Undefined run-ons' are now deserialized and parsed. They are added to a new property `EntryModel.UndefinedResults`
- Language is added to the Entry class (only applies to the Spanish-English dictionary) 
- Several properties in response classes have been renamed to a more appropriate name

1.1.2 - Fix a nullreference exception that occurred when a DictionaryEntry didn't contain any definitions

1.1.1 - Fix for synonyms, they are now removed from text

1.1 - Contains breaking changes: Renamed some properties: 

- `Dto.Sense.RawTranslation` -> `Dto.Sense.RawText`
- `Dto.Sense.Translation` -> `Dto.Sense.Text`
- Renamed some other properties in raw response classes
Added RawSentence to Dto.Example class and remove markup from the Text property

1.0 - Initial version.
