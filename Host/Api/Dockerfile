# Use the official .NET 8.0 SDK image for building the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy the contents of your project into the Docker image
COPY . ./

# Build and publish the application
RUN dotnet publish ./Host/Api/Api.csproj -c Release -o out/api

# Use the official .NET 8.0 ASP.NET Core runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published files from the build stage to the runtime image
COPY --from=build-env /app/out/api .

# INFO Expose port 8080 for the web application
EXPOSE 8080

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Api.dll"]


# bash

# docker build -t host-api -f Host/Api/Dockerfile .
# docker run -it --rm -p 8081:8080 --name web-api host-api
# http://localhost:8081/swagger/index.html
