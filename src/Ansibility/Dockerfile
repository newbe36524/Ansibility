FROM microsoft/aspnetcore:1.0.1
ENTRYPOINT ["dotnet", "Ansibility.dll"]
ARG source=out 
WORKDIR /app
EXPOSE 80
COPY $source .
