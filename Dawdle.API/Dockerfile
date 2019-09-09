FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Dawdle.API/Dawdle.API.csproj", "Dawdle.API/"]
COPY ["Dawdle.Service/Dawdle.Service.csproj", "Dawdle.Service/"]
COPY ["Dawdle.Core/Dawdle.Core.csproj", "Dawdle.Core/"]
COPY ["Dawdle.Database/Dawdle.Database.csproj", "Dawdle.Database/"]
RUN dotnet restore "Dawdle.API/Dawdle.API.csproj"
COPY . .
WORKDIR "/src/Dawdle.API"
RUN dotnet build "Dawdle.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Dawdle.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Dawdle.API.dll"]
