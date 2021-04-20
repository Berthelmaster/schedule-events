# develop stage
FROM arm32v7/node as develop-stage
WORKDIR /app
COPY package*.json ./
RUN yarn global add @quasar/cli
COPY . .

# build stage
FROM develop-stage as build-stage
RUN yarn
RUN quasar build

# production stage
EXPOSE 80
CMD ["quasar", "serve", "-p" "80" "dist"]