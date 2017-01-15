docker stop ansibility
docker rm ansibility
docker rmi ansibility 
del /f /q/ s out
dotnet publish -c Debug -o out 
docker build -t ansibility .
docker run -d -p 8000:80 --name ansibility ansibility