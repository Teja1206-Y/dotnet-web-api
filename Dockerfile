# Use official ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Set working directory
WORKDIR /app

# Copy published output into container
COPY publish/ ./

# Expose port
EXPOSE 5000

# Run the Web API
ENTRYPOINT ["dotnet", "Officeworkflows.Api.dll"]
