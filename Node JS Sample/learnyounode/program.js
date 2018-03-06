var path = require('path')

var fs = require('fs')
var dir = process.argv[2];
var filter = process.argv[3];

fs.readdir(dir, function (err, files) {
  if (err) throw err;
  for(var i=0; i<files.length; i++){
    if (path.extname(files[i]).replace('.','') == filter){
      console.log(files[i])
    }
  }
});



/*
for (var i = 2; i < process.argv.length; i++) {
  sum += Number(process.argv[i]);
}

console.log(sum);
*/
