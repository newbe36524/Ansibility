docker stop student
docker rm student
docker rmi student 
del /f /q/ s out
dotnet publish -c Debug -o out 
docker build -t student .
docker run -d -p 8000:80 --name student student
