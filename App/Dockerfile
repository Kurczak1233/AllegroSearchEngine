# base image
FROM node:16.13.0-alpine

WORKDIR /app

COPY ["Mobile/app","."]

RUN yarn install
RUN yarn build

EXPOSE 3000
CMD [ "yarn", "dev" ]