var fs = require('fs');
var http = require('http')
var request = require('request')
var port = Number(process.argv[2])

/*
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
})*/
var server = http.createServer(function (req, resp) {
  var url = require('url').parse(req.url, true)
  var query = new Date(url.query.iso)
  var pathname = url.pathname
  resp.writeHead(200, { 'Content-Type': 'application/json' })
  resp.write(JSON.stringify(processURL(pathname, query)))
  resp.end()
})
server.on('clientError', function(err, socket) {
  socket.end('HTTP/1.1 400 Bad Request\r\n\r\n')
})
server.listen(port)

function processURL(pathname, query) {
  var output = '';
  switch(pathname) {
    case "/api/parsetime":
    output = parseTime(query);
    break;
    case "/api/unixtime":
    output = unixTime(query);
    break;
    default:
    output = "Error processing url"
    break;
  }
  return output;
}

function parseTime(query) {
return { hour: query.getHours(),
minute: query.getMinutes(),
second: query.getSeconds() }
}
function unixTime(query) {
  return { unixtime: query.getTime() }
}
