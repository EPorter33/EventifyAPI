# Stage 1: Build & Publish using .NET 10 SDK
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /home/app

COPY . .

RUN dotnet restore EventifyAPI.csproj
RUN dotnet publish EventifyAPI.csproj -c Release -o /publish

# Stage 2: Runtime using .NET 10 ASP.NET image
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /publish
COPY --from=build /publish .

ENV ASPNETCORE_URLS="http://0.0.0.0:5000"
ENTRYPOINT ["dotnet", "EventifyAPI.dll"]