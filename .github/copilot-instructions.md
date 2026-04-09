---
description: "Workspace-level Copilot instructions for MerriamWebster.NET, including reference to the Merriam-Webster JSON dictionary API docs."
---

This repository implements a .NET client and parser for the Merriam-Webster dictionary APIs.

Key points for Copilot:

- This is a .NET library targeting `MerriamWebster.NET`, with parsing logic located under `source/MerriamWebster.NET/MerriamWebster.NET/Parsing`.
- API responses are expected to be JSON arrays of dictionary entries, but the service may return alternative payloads for errors or suggestions.
- Invalid or unexpected responses may contain plain text, HTML, or JSON objects instead of an array. Always validate HTTP status codes and response content before parsing.
- Encode search terms and query values using `Uri.EscapeDataString`, and use `ToLowerInvariant()` for dictionary lookup paths when building request URLs.
- Avoid disposing an injected `HttpClient` if the class is used with dependency injection.
- When parsing responses:
  - handle empty or whitespace bodies gracefully,
  - detect non-array JSON root objects and return an empty result model rather than throwing,
  - ignore suggestion lists of strings when an exact entry result is expected,
  - preserve raw response text only when `MerriamWebsterConfig.IncludeRawResponse` is enabled.
- Add detailed logging for diagnostics, including response previews when JSON parsing fails, expected root value kinds, and non-success HTTP responses.
- The Merriam-Webster JSON API documentation is available here: https://dictionaryapi.com/products/json
- Use that documentation as the authoritative source for JSON structure, endpoint behavior, and error formats when working on parsing or API request code.
- keep the readme up-to-date with usage examples and any changes to the API client behavior or configuration options.

Do not assume every response is valid JSON; handle status codes, empty responses, text errors, invalid search results, and alternate response shapes gracefully.
