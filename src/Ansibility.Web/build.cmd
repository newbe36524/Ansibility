docker stop Ansibility
docker rm Ansibility
docker rmi Ansibility 
del /f /q/ s out
dotnet publish -c Debug -o out 
docker build -t Ansibility .
docker run -d -p 8000:80 --name Ansibility Ansibility