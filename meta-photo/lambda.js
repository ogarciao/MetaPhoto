const awsServerlessExpress = require('aws-serverless-express');
const app = require("./dist/meta-photo/server");
const awsServerlessExpressMiddleware = require('aws-serverless-express/middleware');

const serverProxy = awsServerlessExpress.createServer(app.server);
module.exports.ssrserverless = (event, context) => awsServerlessExpress.proxy(serverProxy, event, context);