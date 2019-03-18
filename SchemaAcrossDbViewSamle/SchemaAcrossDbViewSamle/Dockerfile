FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY SchemaAcrossDbViewSamle/SchemaAcrossDbViewSamle.csproj SchemaAcrossDbViewSamle/
RUN dotnet restore SchemaAcrossDbViewSamle/SchemaAcrossDbViewSamle.csproj
COPY . .
WORKDIR /src/SchemaAcrossDbViewSamle
RUN dotnet build SchemaAcrossDbViewSamle.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SchemaAcrossDbViewSamle.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SchemaAcrossDbViewSamle.dll"]
