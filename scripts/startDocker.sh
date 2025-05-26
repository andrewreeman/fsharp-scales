#! /bin/bash

docker build . -t scales-api:latest
docker run -d -p 5000:5000 scales-api:latest