FROM mcr.microsoft.com/dotnet/sdk:10.0.100-preview.5@sha256:15e549861d6e9be8c80d6a3c506f09d9dee8169521a2d6d067a95347148b15cc	AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0.0-preview.5@sha256:c42a3a8e95bdc49ff80b92f1d3a7d31bdc2f1c27d746933da5ce1fc867f077b0
WORKDIR /App
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://*:5291
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "ScalesWeb.dll"]
