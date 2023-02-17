const serverlessExpress = require("aws-serverless-express");
const app = require("./dist/meta-photo/serverless/main");
const serverProxy = serverlessExpress.createServer(app.server);
module.exports.handler = (event, context) => serverlessExpress.proxy(serverProxy, event, context);