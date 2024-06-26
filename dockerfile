# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container

WORKDIR /app
# Copy the project file(s) to the container
COPY ./*.csproj ./

# Restore the NuGet packages
#RUN ./src/TodoistClone.Api/ dotnet restore

# Copy the rest of the source code to the container
COPY . .

# Build the application
RUN dotnet build -c Release /app

# Publish the application
RUN dotnet publish -c Release --no-build -o /publish

# Use the official .NET runtime image as the base image for the final image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final

# Set the working directory inside the container
WORKDIR /app

# Copy the published output from the build image to the final image
COPY --from=build  /publish ./
#RUN chmod +x ./app/publish/TodoistClone.Api

# Expose the port number that the application listens on
EXPOSE 8080

# Set the entry point for the container
ENTRYPOINT [ "dotnet", "./TodoistClone.Api.dll" ] 