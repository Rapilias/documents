
# dotnet tool restore
dotnet DocFxTocGenerator --docfolder ./docs --outputfolder ./docs && dotnet run --project docfx-toc-tools/docfx-toc-tools.csproj
# dotnet docfx ./docs/docfx.json --serve
dotnet docfx build ./docs/docfx.json
