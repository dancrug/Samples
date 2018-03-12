var http = require('http')

var output = new Array(2);
var outcount = 0;
var urls = new Array();

for(var i = 2; i<process.argv.length;i++) {
  urls.push(process.argv[i]);
}

urls.forEach(function (url, index) {
  http.get(url, function(res) {
    var result = '';
    res.setEncoding('utf-8')
    res.on('error', function (e) {

    })
    res.on('data', function (data) {
      result += data;
    })
    res.on('end', function () {
      output[index] = result;
    })
  }).on("error", function (e) {

  })
});

console.log(output)


/*
for(var i=2;i<=4;i++) {
  var url = process.argv[i];
  processURL(url, output, outcount, callback, i)
}


function processURL (url, output, outcount, callback, index) {
  http.get(url, function(res) {
    var result = '';
    res.setEncoding('utf8')
    res.on('error', function (e) {
      callback(e, null, null, null)
    });
    res.on('data', function(data) {
      result += data;
    });
    res.on('end', function() {
      callback(null, result, output, outcount, index)
    });
  }).on('error', function(e) {
    callback(e, null, null, null)
  });
}

function callback(err, result, output, outcount, index) {
  if(err)
    console.log(err)
  else if(index == 4)
    console.log(output)
  else
    output[outcount] = result;
    outcount++;

  console.log(index)
}*/
