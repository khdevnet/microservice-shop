#!/bin/bash
cd ./Web/
set -ev
dotnet restore
dotnet build -c Release
cd ..
