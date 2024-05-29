FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY ./obj/docker/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "SmartHome.Api.dll"]