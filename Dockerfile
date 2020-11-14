FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime
WORKDIR /app
EXPOSE 80


# copy and publish app and libraries
COPY . ./


RUN dotnet restore ./back-end-mega-hack-5/back-end-mega-hack-5.sln
RUN dotnet build ./back-end-mega-hack-5/back-end-mega-hack-5.sln --no-restore -c Release

RUN dotnet publish ./back-end-mega-hack-5/back-end-mega-hack-5.sln -c Release -o published


CMD ASPNETCORE_URLS=http://*:$PORT dotnet published/back-end-mega-hack-5.dll
