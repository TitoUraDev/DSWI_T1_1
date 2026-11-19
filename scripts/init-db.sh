#!/usr/bin/env bash
# Ejecuta los scripts SQL dentro del contenedor (alternativa a hacerlo desde DBeaver)
set -e
cd "$(dirname "$0")/.."
PASS="DswiT1_Passw0rd!"
[ -f .env ] && source .env && PASS="${MSSQL_SA_PASSWORD:-$PASS}"
for f in 01_ClinicaDB.sql 02_StoredProcedures.sql; do
  echo ">> Ejecutando $f"
  docker exec -i clinicadb-sql /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$PASS" -C -b -i "/scripts/$f"
done
echo "Listo."
