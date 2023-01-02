# #stage 1
# FROM node:lts-alpine3.14 as node
# WORKDIR /app

# COPY package.json .
# RUN npm install
# COPY . .

# EXPOSE 4200

# RUN npm run build --prod

# #stage 2
# FROM nginx:alpine
# COPY --from=node /app/dist/angular /usr/share/nginx/html


### STAGE 1: Build ###
FROM node:lts-alpine3.14 AS build
WORKDIR /app
COPY package.json .
RUN npm install --legacy-peer-deps
COPY . .
RUN npm run build --prod

### STAGE 2: Run ###
FROM nginx:1.21.6-alpine
COPY --from=build /app/dist/* /usr/share/nginx/html
EXPOSE 80

### STAGE 3: Update env variables on container startup ###
RUN echo 'before envsubst'
CMD ["/bin/sh",  "-c",  "envsubst < /usr/share/nginx/html/env.template.js > /usr/share/nginx/html/env.js && exec nginx -g 'daemon off;'"]
RUN echo 'after envsubst'
