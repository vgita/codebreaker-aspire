FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Codebreaker.GameAPIs/Codebreaker.GameAPIs.csproj", "Codebreaker.GameAPIs/"]
RUN dotnet restore "Codebreaker.GameAPIs/Codebreaker.GameAPIs.csproj"
COPY . .
WORKDIR "/src/Codebreaker.GameAPIs"
RUN dotnet build "Codebreaker.GameAPIs.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Codebreaker.GameAPIs.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Codebreaker.GameAPIs.dll"]
