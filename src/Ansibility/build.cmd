docker stop student
docker rm student
docker rmi student 
del /f /q/ s out
mkdir out 
copy nul "out/.dockerignore"
dotnet publish -c Debug -o out
docker build -t student .
docker run -d -p 8000:80 --name student student