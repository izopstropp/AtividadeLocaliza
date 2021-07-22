FROM mcr.microsoft.com/dotnet/sdk:3.1

ARG BUILD_CONFIGURATION=Release
ENV ASPNETCORE_ENVIRONMENT=Release
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV ASPNETCORE_URLS=http://+:5000

WORKDIR /App

COPY AtividadeLocaliza.WebApi/bin/Release/netcoreapp3.1 /App

ENTRYPOINT [ "dotnet","AtividadeLocaliza.WebApi.dll" ]

EXPOSE 5000