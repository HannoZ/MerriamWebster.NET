1.1.2 - Fix a nullreference exception that occurred when a DictionaryEntry didn't contain any definitions

1.1.1 - Fix for synonyms, they are now removed from text

1.1 - Contains breaking changes: Renamed some properties: 

- `Dto.Sense.RawTranslation` -> `Dto.Sense.RawText`
- `Dto.Sense.Translation` -> `Dto.Sense.Text`
- Renamed some other properties in raw response classes
Added RawSentence to Dto.Example class and remove markup from the Text property

1.0 - Initial version.
