FROM mcr.microsoft.com/dotnet/core/sdk as build

WORKDIR /build
COPY . . 
RUN dotnet build TravelPlanner.App

FROM mcr.microsoft.com/dotnet/core/aspnet

COPY --from=build /build/TravelPlanner.App/bin/Debug/netcoreapp3.1 ./bin
COPY --from=build /build/TravelPlanner.App/obj/Debug/netcoreapp3.1 ./obj

ENTRYPOINT dotnet bin/TravelPlanner.App.dll