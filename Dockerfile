FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 13244
ENV ASPNETCORE_URLS=http://+:13244

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "GrocerioApi" -c Release -o /app

FROM base AS final

WORKDIR /app

COPY ./GrocerioDesktop/Resources/* /app/Resources/
COPY ./GrocerioApi/Resources/* /app/Resources/
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "GrocerioApi.dll"]