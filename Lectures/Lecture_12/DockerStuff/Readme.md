# Docker stuff
Contains project on which was shown how to run app in docker

## Info
App needs to be build and published before putting it in container

## Docker image building
docker build -t dockered-app .

docker build is command for creation of docker image
-t dockered-app = to set up name - name is not required but you can't create container from image without name
. = place where to find Dockerfile

## Docker container running
docker run --rm -t dockered-app

docker run is command for creating container from image and starting it
--rm = remove container when finished
-t = connect this console to container one

## Full documentation for docker
https://docs.docker.com/reference/
