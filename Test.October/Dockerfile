FROM ubuntu/dotnet-aspnet:8.0-24.04_stable AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Test.October/Test.October.csproj", "Test.October/"]
RUN dotnet restore "Test.October/Test.October.csproj"
COPY . .
WORKDIR "/src/Test.October"
RUN dotnet build "Test.October.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Test.October.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.October.dll"]
