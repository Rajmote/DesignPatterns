#!/usr/bin/env pwsh
# Convenience wrapper for `dotnet format`.
# Plain `dotnet format` errors in this repo because the folder holds BOTH a .sln and a .csproj,
# so it can't decide which workspace to use. This always targets the solution.
#
#   .\format.ps1                     # format everything
#   .\format.ps1 --verify-no-changes # check only (used by CI / the pre-commit hook)
#
# Extra arguments are forwarded to dotnet format.
dotnet format "$PSScriptRoot/DesignPatterns.sln" @args
