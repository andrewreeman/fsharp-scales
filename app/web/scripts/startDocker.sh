#! /bin/bash
echo "Building and starting scales-api container..."
docker build . -t scales-web:latest

## Are there any running containers even if stopped? If so then remove them
if [ "$(docker ps -a -q -f name=scales-web)" ]; then
  echo "Stopping and removing existing scales-web container..."
  docker container stop scales-web
  docker container rm scales-web
fi

echo "Running scales-api container..."
docker run -d -p 5291:5291 --name scales-web --restart unless-stopped --add-host=host.docker.internal:host-gateway scales-web:latest 