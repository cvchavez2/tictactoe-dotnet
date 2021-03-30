FROM mcr.microsoft.com/dotnet/core/sdk as build-env
WORKDIR /app

COPY Tictactoe.Service/*.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish Tictactoe.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /dist
COPY --from=build-env /app/out .
CMD [ "dotnet", "Tictactoe.Service.dll" ]