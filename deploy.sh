#!/bin/bash
set -ev

# ---------------------------------
# DEPLOY
# ---------------------------------

TAG=$1
DOCKER_USERNAME=$2
DOCKER_PASSWORD=$3

# Create publish artifact
dotnet publish -c Release src

# Remove a leading v from the major version number (e.g. if the tag was v1.0.0)
IFS='.' read -r -a tag_array <<< "$TAG"
MAJOR="${tag_array[0]//v}"
MINOR=${tag_array[1]}
BUILD=${tag_array[2]}
SEMVER="$MAJOR.$MINOR.$BUILD"

# Build the Docker images
docker build -t khdevnet/shop:$SEMVER Web/bin/Release/netcoreapp1.1/publish/.
docker tag khdevnet/shop:$SEMVER khdevnet/shop:latest

# Login to Docker Hub and upload images
docker login -u="$DOCKER_USERNAME" -p="$DOCKER_PASSWORD"
docker push khdevnet/shop:$SEMVER
docker push khdevnet/shop:latest