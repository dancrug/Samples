var fs = require('fs');
var http = require('http')
var request = require('request')
var port = Number(process.argv[2])

var server = http.createServer(function (req, resp) {
  var body = '';
  req.setEncoding('utf-8')
  req.on('data', function(chunk) {
    body += chunk
  }).on('end', function (chunk) {
    resp.write(body.toString().toUpperCase())
    resp.end()
  }).on('error', function(err) {
    console.log(err)
  }).on('timeout', function(err) {
    console.log(err)
  }).on('close', function(chunk) {
  }).on('finish', function(chunk) {
  })

})
server.listen(port)
