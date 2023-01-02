FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# copy csproj into container and execute dotnet restore
WORKDIR /src
COPY LuckyNumberGenerator.csproj ./LuckyNumberGenerator/
WORKDIR /src/LuckyNumberGenerator
RUN dotnet restore

# copy all other files and then publish the app
WORKDIR /src
COPY . ./LuckyNumberGenerator/
WORKDIR /src/LuckyNumberGenerator
RUN dotnet publish -c release -o /app --no-restore

# we've published, let's finally set th entrypoint
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "LuckyNumberGenerator.dll"]
