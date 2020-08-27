FROM mcr.microsoft.com/dotnet/core/sdk
COPY ./bin/Release/netcoreapp3.1/linux-x64/publish /app
WORKDIR /app
RUN chmod +x -R /app/TravelPlanner.App
EXPOSE 5000
EXPOSE 5001
ENTRYPOINT ./TravelPlanner.App