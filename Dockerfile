FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src

COPY QuickBackend/*.csproj QuickBackend/
#COPY DependencyProject1/*.csproj DependencyProject1/

RUN dotnet restore QuickBackend/QuickBackend.csproj
COPY . .

WORKDIR /src/QuickBackend
RUN dotnet publish QuickBackend.csproj -c Release -o /app

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app .
CMD ["dotnet", "QuickBackend.dll"]