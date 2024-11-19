FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /Back
COPY Reto-Back.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /Back
COPY --from=build-env /Back/out .
ENTRYPOINT ["dotnet", "Reto-Back.dll"]