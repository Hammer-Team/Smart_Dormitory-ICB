#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 55684
EXPOSE 44389

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["WebSmartDormitory/WebSmartDormitory.csproj", "WebSmartDormitory/"]
RUN dotnet restore "WebSmartDormitory/WebSmartDormitory.csproj"
COPY . .
WORKDIR "/src/WebSmartDormitory"
RUN dotnet build "WebSmartDormitory.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebSmartDormitory.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebSmartDormitory.dll"]