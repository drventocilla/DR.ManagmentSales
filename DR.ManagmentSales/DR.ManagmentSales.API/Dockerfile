#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM  mcr.microsoft.com/dotnet/aspnet:6.0 AS base 
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DR.ManagmentSales/DR.ManagmentSales.API/DR.ManagmentSales.API.csproj" ,"src/DR.ManagmentSales.API/"]
COPY ["DR.ManagmentSales/DR.ManagmentSales.Application/DR.ManagmentSales.Application.csproj", "src/DR.ManagmentSales.Application/"]
COPY ["DR.ManagmentSales/DR.ManagmentSales.Domain/DR.ManagmentSales.Domain.csproj", "src/DR.ManagmentSales.Domain/"]
COPY ["DR.ManagmentSales/DR.ManagmentSales.Infrastructure/DR.ManagmentSales.Infrastructure.csproj", "src/DR.ManagmentSales.Infrastructure/"]
COPY ["DR.ManagmentSales/Core/Core.csproj", "src/Core/"]
RUN dotnet restore "src/DR.ManagmentSales.API/DR.ManagmentSales.API.csproj"

COPY . .
WORKDIR "/src/src/DR.ManagmentSales.API"
RUN dotnet build "DR.ManagmentSales.API.csproj" --no-restore -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "DR.ManagmentSales.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DR.ManagmentSales.API.dll"]

