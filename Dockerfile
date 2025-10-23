FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SampleApi.csproj", "."]
RUN dotnet restore "SampleApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SampleApi.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
ENV ASPNETCORE_HTTP_PORTS=5001
EXPOSE 5001 
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "SampleApi.dll"]