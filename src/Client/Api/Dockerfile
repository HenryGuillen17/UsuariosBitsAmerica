FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Client/Api/Api.csproj", "src/Client/Api/"]
COPY ["src/Services/Services/Services.csproj", "src/Services/Services/"]
COPY ["src/Models/Models/Models.csproj", "src/Models/Models/"]
COPY ["src/UnitOfWork/UnitOfWork.Interfaces/UnitOfWork.Interfaces.csproj", "src/UnitOfWork/UnitOfWork.Interfaces/"]
COPY ["src/Persistence/Persistence.Interfaces/Persistence.Interfaces.csproj", "src/Persistence/Persistence.Interfaces/"]
COPY ["src/UnitOfWork/UnitOfWork.SqlServer/UnitOfWork.SqlServer.csproj", "src/UnitOfWork/UnitOfWork.SqlServer/"]
COPY ["src/Persistence/Persistence.SqlServer/Persistence.SqlServer.csproj", "src/Persistence/Persistence.SqlServer/"]
RUN dotnet restore "src/Client/Api/Api.csproj"
COPY . .
WORKDIR "/src/src/Client/Api"
RUN dotnet build "Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.dll"]