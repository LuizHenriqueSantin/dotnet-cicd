FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY DotnetCicdDemo.slnx ./
COPY src/Calculator/Calculator.csproj src/Calculator/
COPY tests/Calculator.Tests/Calculator.Tests.csproj tests/Calculator.Tests/
RUN dotnet restore

COPY . .
RUN dotnet build --no-restore --configuration Release

ENTRYPOINT ["dotnet", "test", "--no-build", "--configuration", "Release"]
