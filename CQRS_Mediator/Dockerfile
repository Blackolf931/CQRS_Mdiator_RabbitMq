#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CQRS_Mediator/CQRS_Mediator.csproj", "CQRS_Mediator/"]
COPY ["BLL/BLL.csproj", "BLL/"]
COPY ["DAL/DAL.csproj", "DAL/"]
RUN dotnet restore "CQRS_Mediator/CQRS_Mediator.csproj"
COPY . .
WORKDIR "/src/CQRS_Mediator"
RUN dotnet build "CQRS_Mediator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CQRS_Mediator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRS_Mediator.dll"]