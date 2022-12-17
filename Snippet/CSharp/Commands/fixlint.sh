#!/bin/bash -xeu

cd `dirname $0` && cd ../

FORMAT_SHARED_OPTION="
  --exclude **/External
  --exclude **/Plugins
  --exclude **/Generated"

dotnet tool install dotnet-format \
  --version "6.4.352107" \
  --add-source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet6/nuget/v3/index.json

dotnet tool run dotnet-format -- Unity/Assembly-CSharp.csproj whitespace ${FORMAT_SHARED_OPTION}
dotnet tool run dotnet-format -- Unity/Assembly-CSharp.csproj style ${FORMAT_SHARED_OPTION}

dotnet tool uninstall dotnet-format
