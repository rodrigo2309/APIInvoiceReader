FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5242

ENV ASPNETCORE_URLS=http://+:5242

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["APIInvoiceReader.csproj", "./"]
RUN dotnet restore "APIInvoiceReader.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "APIInvoiceReader.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "APIInvoiceReader.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIInvoiceReader.dll"]
