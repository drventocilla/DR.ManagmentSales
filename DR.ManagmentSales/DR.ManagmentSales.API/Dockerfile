#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR ManagmentSales

EXPOSE 80
EXPOSE 5002


COPY ./*.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Realease -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /ManagmentSales
COPY --from=build /ManagmentSales/out .
ENTRYPOINT ["dotnet", "DR.ManagmentSales.API.dll"]