# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source


# copy csproj and restore as distinct layers
#COPY *.sln .
COPY . ./
#COPY BookManageSystemTest/*.csproj ./BookManageSystemTest/
RUN dotnet restore

# copy everything else and build app
#COPY BookManageSystem/. ./BookManageSystem/
#COPY BookManageSystemTest/. ./BookManageSystemTest/
WORKDIR /source/BookManageSystem
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "BookManageSystem.dll","--Logging:LogLevel:Microsoft", "Debug"]
