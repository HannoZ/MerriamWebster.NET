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
