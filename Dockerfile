FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS BASE
COPY ./publish app/
WORKDIR /app
ENTRYPOINT ["dotnet", "WebAPI.dll"]