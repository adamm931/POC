FROM adamm93/iis-remote

ARG publish_folder

COPY --from=adamm93/poc_build_nano:latest /app/${publish_folder} /inetpub/wwwroot