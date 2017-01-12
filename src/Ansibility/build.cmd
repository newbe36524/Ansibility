docker rm student
docker rmi student 
dotnet publish -c Release -o out
docker build -t student .
docker run -d -p 8000:80 --name student student
docker logs student