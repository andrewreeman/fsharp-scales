## RPI Docker
How to get the system running via docker.

Install Docker on raspberry pi.
Add user to docker group:

`sudo usermod -aG docker $USER`

Login using new group:
`newgrp docker`

Now we can run docker without needing sudo.
Next we will build and run the docker container:

`./scripts/startDocker.sh`
