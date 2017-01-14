FROM ansi
ENTRYPOINT ["dotnet", "Ansibility.dll"]
ARG source=out 
WORKDIR /app
EXPOSE 80
COPY $source .

