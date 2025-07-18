FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY back-end.sln ./
COPY back-end.api/*.csproj back-end.api/
COPY back-end.domain/*.csproj back-end.domain/
COPY back-end.data-access/*.csproj back-end.data-access/

RUN dotnet restore

COPY . .

WORKDIR /src/back-end.api

RUN dotnet publish back-end.api.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/out ./

EXPOSE 5154

ENTRYPOINT ["/bin/sh", "-c", "\
  echo '⏳ Waiting for PostgreSQL...'; \
  for i in $(seq 1 30); do \
    timeout 1 bash -c 'cat < /dev/null > /dev/tcp/postgres/5432' 2>/dev/null && break; \
    echo 'Postgres not ready yet... retrying'; \
    sleep 1; \
  done; \
  echo 'PostgreSQL is up - applying migrations...'; \
  dotnet back-end.api.dll migrate && \
  echo '✅ Migrations applied. Starting API'; \
  dotnet back-end.api.dll"]
