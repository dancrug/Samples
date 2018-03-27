var http = require('http')
var outcount = 0;
var urls = new Array();

function init() {
  for(var i = 2; i<process.argv.length;i++) {
    urls.push(process.argv[i]);
  }
  processURLs(urls);
}


function processURLs(urls) {
  var output = new Array();

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
        if(outcount < 2) {
          output.push([index, result]);
          outcount++;
        } else {
          output.push([index, result]);
          callback(output, index, true)
        }
      })
    }).on("error", function (e) {

    })

  });
}

function callback(data, index, done) {
  if(done) {
    data.sort();
    data.forEach(function (item) {
      console.log(item[1])
    });
  }
}

init();
