FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

COPY . /app
WORKDIR /app

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime

WORKDIR /app
COPY --from=build /app/ProfessionalRESTServices/out ./

ENTRYPOINT ["dotnet", "ProfessionalRESTServices.dll"]