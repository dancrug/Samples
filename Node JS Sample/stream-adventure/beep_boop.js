// Lesson 1
var fs = require("fs")
//var file = process.argv[2]
//fs.createReadStream(process.stdin).pipe(process.stdout)

//Lesson 2
//process.stdin.pipe(process.stdout)

//Lesson 3
/*
var body = ''
process.stdin.on('readable', function () {
  var chunk = process.stdin.read();
  if (chunk !== null) {
    body += chunk
  }
});

process.stdin.on('end', function () {
  process.stdout.write(body.toString().toUpperCase());
});
*/

//Lesson 4
/*
var body = ''
process.stdin.on('readable', function () {
  var chunk = process.stdin.read();
  if (chunk !== null) {
    body += chunk
  }
});

process.stdin.on('end', function () {
  var output = body.split('');
  output = output.reverse();
  output = output.join('')
  process.stdout.write(output);
  process.stdout.write("\n");
});
*/

//Lesson 5
/*
var http = require('http')
var fs = require('fs')
var port = process.argv[2];

var server = http.createServer(function (req, resp){
  var body = '';
  req.setEncoding('utf8');
  if(req.method === 'POST') {
    req.on('data', (chunk) => {
      body += chunk;
    });
    req.on('end', () => {
    try {
      var data = body.toUpperCase();
      // write back something interesting to the user:
      resp.write(data);
      resp.end();
    } catch (er) {
      // uh oh! bad json!
      resp.statusCode = 400;
      return resp.end(`error: ${er.message}`);
    }
    });
  }
}).on('error', function(err) {
  console.log(err)
})
server.listen(port)
*/

//Lesson 6
/*
var request = require('request');
var output = request.post('http://localhost:8099/');
process.stdin.pipe(output).pipe(process.stdout)
*/

//Lesson 7
/*
var websocket = require('websocket-stream')
var stream = websocket('ws://localhost:8099')
stream.write("hello\n")
*/

//Lesson 8
/*
var body = ''
process.stdin.on('readable', function () {
  var chunk = process.stdin.read();
  if (chunk !== null) {
    body += chunk
  }
});
process.stdin.on('end', function () {
  var output = body
  var startIndex = output.match("<span class=\"loud\">").index;
  var endIndex = output.match("</span>").index;
  var currentHtml = output.substring(startIndex+19, endIndex);
  //output.replace(currentHtml, currentHtml.toUpperCase())
  output = output.replace(currentHtml, currentHtml.toUpperCase())
  process.stdout.write(output);
});
*/
