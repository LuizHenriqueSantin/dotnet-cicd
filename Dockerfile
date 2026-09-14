FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY DotnetCicdDemo.slnx ./
COPY src/Calculator/Calculator.csproj src/Calculator/
COPY src/Calculator.Api/Calculator.Api.csproj src/Calculator.Api/
COPY tests/Calculator.Tests/Calculator.Tests.csproj tests/Calculator.Tests/
RUN dotnet restore

COPY . .
RUN dotnet publish src/Calculator.Api/Calculator.Api.csproj --no-restore --configuration Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "Calculator.Api.dll"]
