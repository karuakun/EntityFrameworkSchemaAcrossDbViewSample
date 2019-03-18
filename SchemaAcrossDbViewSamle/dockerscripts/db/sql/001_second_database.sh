#!/bin/sh

# Create Second Database
echo "CREATE DATABASE IF NOT EXISTS \`seconddb\` ;" | "${mysql[@]}"
echo "GRANT ALL ON \`seconddb\`.* TO '"$MYSQL_USER"'@'%' ;" | "${mysql[@]}"
echo 'FLUSH PRIVILEGES ;' | "${mysql[@]}"
"${mysql[@]}" < /docker-entrypoint-initdb.d/second_database.sql_
