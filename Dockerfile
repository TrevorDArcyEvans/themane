FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src

COPY . .
RUN dotnet restore Themane.Web.sln

WORKDIR /src
RUN dotnet build --no-incremental Themane.Web.sln -c Release

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM build AS final
WORKDIR /app
COPY --from=publish /app .
#RUN ls -Rall
ENTRYPOINT ["dotnet", "Themane.Web.dll"]
