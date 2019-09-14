@echo off
pushd %0\..\..\Heimdall.IdentityServer
dotnet restore
dotnet ef database update %1 -c ApplicationDbContext
popd
set /p DUMMY=Hit ENTER to continue...