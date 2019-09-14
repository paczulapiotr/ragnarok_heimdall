@echo off
echo Adding Platform migration: %1
pushd %0\..\..
dotnet ef migrations add %1 -o Data\Migrations\Users -p .\Heimdall.IdentityServer -c ApplicationDbContext
popd
set /p DUMMY=Hit ENTER to continue...