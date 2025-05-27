#! /bin/bash
echo "Building and starting scales-api container..."
docker build . -t scales-api:latest

## Are there any running containers even if stopped? If so then remove them
if [ "$(docker ps -a -q -f name=scales-api)" ]; then
  echo "Stopping and removing existing scales-api container..."
  docker container stop scales-api
  docker container rm scales-api
fi

echo "Running scales-api container..."
docker run -d -p 5000:5000 --name scales-api --restart unless-stopped scales-api:latest 
