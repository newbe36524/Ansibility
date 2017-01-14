FROM ansi:1.1.0
ENTRYPOINT ["dotnet", "Ansibility.Web.dll"]
ARG source=./out 
WORKDIR /app
EXPOSE 80
COPY $source ./

